using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastracture.Repositories;

public class CategoryRepository : BaseRepository<Category, CategoryDAO>, ICategoryRepository
{
    public CategoryRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public List<Medicine> GetMedicines(int categoryId)
    {
        return _context
            .Medicines
            .Include(e=>e.CategoryNavigation)
            .Include(e=>e.CompanyNavigation)
            .Where(e => e.Category == categoryId).Select(e => new Medicine()
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

            })
            .ToList();
    }
}
