using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Presentation.Models.User;
using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;
using Pharmacy.SharedKernel.Service;
using System.Security.Claims;
using System.Security.Cryptography;

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
	public virtual IActionResult Index()
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
        try
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Invalid input or missing feild try again";

                return RedirectToAction("Index");
            }
            TempData["message"] = "Added successfully";
            var entity = _mapper.Map<TEntity>(request);
            _service.Add(entity);
            return RedirectToAction("Index");
        }
        catch(Exception)
        {
            TempData["error"] = "Error In The Adding Process";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    virtual public IActionResult ApplyEdit([FromForm]TUpdateRequest request)
    {

        try
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Editing is not valid try it again";

                return RedirectToAction("Index");
            }

            TempData["message"] = "Updated successfully";
            var entity = _mapper.Map<TEntity>(request);
            _service.Update(entity);
            return RedirectToAction(nameof(this.Index));
        }
        catch(Exception)
        {
            TempData["error"] = "Error In The Update Process";
            return RedirectToAction("Index");
        }
    }

   

    public IActionResult Delete(int id)
    {
        try
        {
            var entity = _service.Get(id);
            _service.Delete(entity);
            TempData["message"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
        catch(Exception)
        {
            TempData["error"] = "Error In The Delete Process";
            return RedirectToAction("Index");
        }
    }
}
