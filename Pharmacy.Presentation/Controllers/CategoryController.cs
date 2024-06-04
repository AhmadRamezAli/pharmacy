using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Category;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers;

public class CategoryController : BaseController<Category, CreateCategoryRequest, UpdateCategoryRequest>
{
    private readonly ICategoryService _categoryService;
    public CategoryController(CategoryService service, IMapper mapper) : base(service, mapper)
    {
        _categoryService = service;
    }
    public IActionResult GetMedicines(int id)
    {
        var entities = _categoryService.GetMedicines(id);
        return View(entities);
    }

}
