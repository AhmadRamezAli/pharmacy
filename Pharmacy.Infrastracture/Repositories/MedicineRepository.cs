using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;

namespace Pharmacy.Infrastracture.Repositories
{
    public class MedicineRepository : BaseRepository<Medicine, MedicineDAO>, IMedicineRepository
    {
        public MedicineRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList)
        {
            var completed = false;

            // Start a transaction

            var executionStrategy = _context.Database.CreateExecutionStrategy();
            executionStrategy.Execute(() =>
            {
                using (var transactionScope = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var ev in eventsList)
                        {
                            if (ev.Type == "Added")
                            {
                                _context.MedicienIngredients.Add(new()
                                {
                                    Ingredient = ev.Id,
                                    Medicine = id
                                });
                                _context.SaveChanges();
                            }
                            if (ev.Type == "Removed")
                            {
                                MedicienIngredientDAO? diseaseMedicine = _context.MedicienIngredients
                                                    .Where(e => e.Medicine == id
                                                    && e.Ingredient == ev.Id)
                                                                .FirstOrDefault();

                                if (diseaseMedicine is not null)
                                {
                                    _context.MedicienIngredients.Remove(diseaseMedicine);
                                    _context.SaveChanges();
                                }
                            }
                        }

                        transactionScope.Commit();

                        completed = true;
                    }
                    catch (Exception)
                    {
                        completed = false;
                        transactionScope.Rollback();
                    }
                }

            });

            return completed;
        }

        public override List<Medicine> GetAll()
        {
            var x = _context.Medicines.OrderByDescending(e=>e.Id).Include(e => e.CategoryNavigation).Include(e => e.CompanyNavigation).Select(e => new Medicine()
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Category = e.Category,
                Company = e.Company,
                ScientificName = e.ScientificName,
                Dosage = e.Dosage,
                CategoryNavigation = _mapper.Map<Category>(e.CategoryNavigation),
                CompanyNavigation = _mapper.Map<Company>(e.CompanyNavigation),

            }).ToList();
            return x;
        }

        public List<Ingredient> GetIngredients(int id)
        {
            List<int> x = _context.MedicienIngredients.Where(e => e.Medicine == id).Select(e => e.Ingredient).ToList();

            List<IngredientDAO> ingredients = new List<IngredientDAO>();
            foreach (int v in x)
            {
                var f = _context.Ingredients.FirstOrDefault(e => e.Id == v);
                if (f != null) { ingredients.Add(f); }

            }
            _context.SaveChanges();

            List<Ingredient> medi = new List<Ingredient>();
            foreach (var z in ingredients)
            {
                medi.Add(_mapper.Map<Ingredient>(z));
            }

            return medi;
        }
    }
}
