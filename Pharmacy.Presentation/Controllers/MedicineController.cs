using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Company;
using Pharmacy.Application.Services.Ingredient;
using Pharmacy.Application.Services.Medicine;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation
    .Controllers
{
    public class MedicineController : BaseController<Medicine, CreateMedicineRequest, UpdateMedicineRequest>
    {
        private readonly IMedicineService medicineService;
        private readonly IIngredientService ingredientService;
        private readonly ICategoryService categoryService;
        private readonly ICompanyService companyService;
        public MedicineController(IMedicineService service, IMapper mapper,ICompanyService companyService,ICategoryService categoryService,IIngredientService ingredientService) : base(service, mapper)
        {
            medicineService=service;
            this.categoryService = categoryService;
            this.companyService = companyService;
            this.ingredientService = ingredientService;
        }
        [Authorize]
        public override IActionResult Index()
        {
            var entities = medicineService.GetAll();
            ViewBag.CompanyList = new SelectList(companyService.GetAll().ToList(), "Id", "Name");
            ViewBag.CategoryList = new SelectList(categoryService.GetAll().ToList(), "Id", "Name");
            return View(entities);
        }

        public List<Medicine> ListOfMedicine()
        {
            var entities = medicineService.GetAll();

            return entities;
        }
        public IActionResult Attach(int id)
        {
            var ingredients = ingredientService.GetAll();
            ViewBag.Ingredients = new SelectList(ingredients.Select(e => new
            {
                Id = e.Id,
                Name = e.Name
            }), "Id", "Name");

            ViewBag.Medicine = medicineService.Get(id);
            return View("Attach", ingredients);
        }
        public IActionResult GetIngredients(int id)
        {
            List<Ingredient> entities = medicineService.GetIngredients(id);

            return Ok(entities);
        }

        [HttpPost]
        public virtual IActionResult ApplyEventsEditing([FromRoute] int id, [FromBody] List<AttachEventDTO> eventsList)
        {
            return Ok(medicineService.ApplyEventChanges(id, eventsList));
        }
    }
}
