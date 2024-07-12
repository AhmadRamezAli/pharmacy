using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastracture.Repositories
{
    internal class DiseaseRepository : BaseRepository<Disease, DiseaseDAO>, IDiseaseRepository
    {
        public DiseaseRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
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
                                _context.DiseaseMedicines.Add(new DiseaseMedicineDAO()
                                {
                                    Medicine = ev.Id,
                                    Disease = id
                                });
                                _context.SaveChanges();
                            }
                            if (ev.Type == "Removed")
                            {
                                DiseaseMedicineDAO? diseaseMedicine = _context.DiseaseMedicines
                                                    .Where(e => e.Disease == id
                                                    && e.Medicine == ev.Id)
                                                                .FirstOrDefault();

                                if (diseaseMedicine is not null)
                                {
                                    _context.DiseaseMedicines.Remove(diseaseMedicine);
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

        public List<Medicine> GetMedicineForDisease(int id)
        {

            List<int> x = _context.DiseaseMedicines.Where(e => e.Disease == id).Select(e => e.Medicine).ToList();

            List<MedicineDAO> medicines = new List<MedicineDAO>();
            foreach (int v in x)
            {
                var f = _context.Medicines.FirstOrDefault(e => e.Id == v);
                if (f != null) { medicines.Add(f); }

            }
            _context.SaveChanges();

            List<Medicine> medi = new List<Medicine>();
            foreach (var z in medicines)
            {
                medi.Add(_mapper.Map<Medicine>(z));
            }

            return medi;
        }


    }
}
