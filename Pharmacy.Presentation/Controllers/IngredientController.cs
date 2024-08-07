﻿using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Controllers;
using Pharmacy.Presentation.Models.Disease;
using Pharmacy.Presentation.Models.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Application;
using Pharmacy.Application.Services.Ingredient;
using Microsoft.AspNetCore.Http;

namespace Pharmacy.Presentation.Controllers
{
   
}
public class IngredientController : BaseController<Ingredient, CreateIngredientRequest, UpdateIngredientRequest>
{
    public IngredientController(IIngredientService service, IMapper mapper) : base(service, mapper)
    {
    }
}
