using Pharmacy.Domain.Entities;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Category;

public interface ICategoryService : IService<Pharmacy.Domain.Entities.Category>
{
    public List<Medicine> GetMedicines(int categoryId);
}
