using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Controllers;
using Pharmacy.Presentation.Models.Disease;
using Pharmacy.Presentation.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
   
}
public class IngredientController : BaseController<Ingredient, CreateIngredientRequest, UpdateIngredientRequest>
{
    public IngredientController(BaseService<Ingredient> service, IMapper mapper) : base(service, mapper)
    {
    }
}
