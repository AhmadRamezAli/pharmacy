using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers;

public class CategoryController : BaseController<Category, CreateCategoryRequest, UpdateCategoryRequest>
{
    public CategoryController(BaseService<Category> service, IMapper mapper) : base(service, mapper)
    {
    }
}
