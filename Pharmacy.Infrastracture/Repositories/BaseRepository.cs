using AutoMapper;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;
using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;
using Pharmacy.SharedKernel.Repository;

namespace Pharmacy.Infrastracture.Repositories;

public class BaseRepository<TEntity, TDAO> : IRepository<TEntity>
    where TEntity : Entity
    where TDAO : DAO
{

    protected readonly PharmacyContext _context;
    protected readonly IMapper _mapper;

    public BaseRepository(PharmacyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public TEntity Add(TEntity entity)
    {
        TDAO dao = _mapper.Map<TDAO>(entity);
        _context.Set<TDAO>().Add(dao);
        _context.SaveChanges();

        entity.Id = dao.Id;
        return entity;
    }

    public void Delete(TEntity entity)
    {
        TDAO dao = _mapper.Map<TDAO>(entity);
        _context.Set<TDAO>().Remove(dao);
        _context.SaveChanges();
    }

    public TEntity Get(int id)
    {
        TDAO? res = _context.Set<TDAO>().FirstOrDefault(e => e.Id == id);
        return _mapper.Map<TEntity>(res);
    }

    public List<TEntity> GetAll()
    {
        return _context.Set<TDAO>().Select(e => _mapper.Map<TEntity>(e)).ToList();
    }

    public PaginatedResponse<TEntity> GetPage(PaginatedRequest request)
    {
        return new PaginatedResponse<TEntity>()
        {
            Count = _context.Set<TDAO>().Count(),
            PayLoad = _context.Set<TDAO>()
                    .OrderBy(e=>e.Id)
                    .Skip(request.PageSize*(request.PageNumber - 1))
                    .Take(request.PageSize)
                    .Select(e => _mapper.Map<TEntity>(e))
                    .ToList()
        };
    }

    #region Update
    public void Update(TEntity entity)
    {
         TDAO dao = _mapper.Map<TDAO>(entity);
        _context.Set<TDAO>().Update(dao);
        _context.SaveChanges();
        entity.Id = dao.Id;
    }
    #endregion
}