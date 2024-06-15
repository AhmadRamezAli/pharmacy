using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services.Category;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Category;

namespace Pharmacy.Presentation.Controllers;

public class CategoryController : BaseController<Category, CreateCategoryRequest, UpdateCategoryRequest>
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService service, IMapper mapper) : base(service, mapper)
    {
        _categoryService = service;
    }
    public IActionResult GetMedicines(int id)
    {
        var entities = _categoryService.GetMedicines(id);
        return View(entities);
    }

}
