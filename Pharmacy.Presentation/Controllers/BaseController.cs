using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;

namespace Pharmacy.Presentation.Controllers;

public class BaseController<TEntity, TCreateRequest,TUpdateRequest> : Controller
    where TEntity : Entity 
    where TCreateRequest :  ICreateRequest
    where TUpdateRequest : IUpdateRequest
{
    private readonly BaseService<TEntity> _service;
    private readonly IMapper _mapper;

    public BaseController(BaseService<TEntity> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var entities = _service.GetAll();
        return View(entities);
    }

    public IActionResult Add(TCreateRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        _service.Add(entity);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(TUpdateRequest request)
    {
        var entity = _mapper.Map<TEntity>(request);
        _service.Update(entity);
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int id)
    {
        var entity = _service.Get(id);
        _service.Delete(entity);
        return View();
    }

}
