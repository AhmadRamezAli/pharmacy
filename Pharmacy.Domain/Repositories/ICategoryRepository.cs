using Pharmacy.Domain.Entities;
using Pharmacy.SharedKernel.Repository;

namespace Pharmacy.Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    public List<Medicine> GetMedicines(int categoryId);
}
