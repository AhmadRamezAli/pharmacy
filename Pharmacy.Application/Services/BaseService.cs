using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;
using Pharmacy.SharedKernel.Repository;
using Pharmacy.SharedKernel.Service;

namespace Pharmacy.Application.Services;

internal class BaseService<TEntity> : IService<TEntity>
    where TEntity : Entity
{
    private readonly IRepository<TEntity> _repository;

    public BaseService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public TEntity Add(TEntity entity)
    {
        return _repository.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _repository.Delete(entity);
    }

    public TEntity Get(int id)
    {
        return _repository.Get(id);
    }

    public List<TEntity> GetAll()
    {
        return _repository.GetAll();
    }

    public PaginatedResponse<TEntity> GetPage(PaginatedRequest request)
    {
      return  _repository.GetPage(request);
    }

    public void Update(TEntity entity)
    {
        _repository.Update(entity);
    }
}
