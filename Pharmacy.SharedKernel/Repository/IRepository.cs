using Pharmacy.SharedKernel.DTO;

namespace Pharmacy.SharedKernel.Repository;

public interface IRepository<TEntity>
    where TEntity : Pharmacy.SharedKernel.Entities.Entity
{
    TEntity Add(TEntity entity);
    TEntity Get(int id);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    List<TEntity> GetAll();
    PaginatedResponse<TEntity> GetPage(PaginatedRequest request);
}
