using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;
using Pharmacy.SharedKernel.Service;

namespace Pharmacy.Presentation.Controllers;

public class BaseController<TEntity, TCreateRequest,TUpdateRequest> : Controller
    where TEntity : Entity 
    where TCreateRequest :  ICreateRequest
    where TUpdateRequest : IUpdateRequest
{
    protected readonly IService<TEntity> _service;
    protected readonly IMapper _mapper;

	public BaseController(IService<TEntity> service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [Authorize]
	public IActionResult Index()
    {
        var entities = _service.GetAll();
        return View(entities);
    }
    [Authorize]
    virtual public IActionResult Create()
    {
        return View();
    }
    [Authorize]
    virtual public IActionResult Edit(int id)
    {
        var entity = _service.Get(id);
        return View(_mapper.Map<TUpdateRequest>(entity));
    }


    [HttpPost]
  
    virtual public IActionResult ApplyCreate([FromForm]TCreateRequest request)
    {
        if(!ModelState.IsValid)
        {
            throw new Exception();
        }
        var entity = _mapper.Map<TEntity>(request);
        _service.Add(entity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    virtual public IActionResult ApplyEdit([FromForm]TUpdateRequest request)
    {
        if (!ModelState.IsValid)
        {
            throw new Exception();
        }
        var entity = _mapper.Map<TEntity>(request);
        _service.Update(entity);
        return RedirectToAction(nameof(this.Index));
    }

   

    public IActionResult Delete(int id)
    {
        var entity = _service.Get(id);
        _service.Delete(entity);
        return RedirectToAction("Index");
    }
}
