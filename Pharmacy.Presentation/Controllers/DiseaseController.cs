using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Disease;
using Pharmacy.Application.Services.Medicine;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Presentation.Models.Disease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
    public class DiseaseController : BaseController<Disease, CreateDiseaseRequest, UpdateDiseaseRequest>
    {
        public IDiseaseService _diseaseService;
        public IMedicineService _medicineService;
        public DiseaseController(IDiseaseService service, IMapper mapper, IMedicineService medicineService) : base(service, mapper)
        {
            _diseaseService = service;
            _medicineService = medicineService;
        }


        public IActionResult Attach(int id)
        {
            var medicines = _medicineService.GetAll();
            ViewBag.Medicines = new SelectList(medicines.Select(e => new
            {
                Id = e.Id,
                Name = e.Name
            }), "Id", "Name");

            ViewBag.Disease = _diseaseService.Get(id);
            return View("Attach", medicines);
        }
        public IActionResult GetMedicines(int id)
        {
            var entities = _diseaseService.GetMedicineForDisease(id);

            return Ok(entities);
        }


        [HttpPost]
        public virtual IActionResult ApplyEventsEditing([FromRoute] int id, [FromBody] List<AttachEventDTO> eventsList)
        {
            return Ok(_diseaseService.ApplyEventChanges(id,eventsList));
        }
    }
}
