using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Category;

internal class CategoryService : BaseService<Domain.Entities.Category>,ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public List<Medicine> GetMedicines(int categoryId)
    {
        return _repository.GetMedicines(categoryId);
    }
}
