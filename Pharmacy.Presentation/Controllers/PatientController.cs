using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Disease;
using Pharmacy.Application.Services.Ingredient;
using Pharmacy.Application.Services.Medicine;
using Pharmacy.Application.Services.Patient;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Patient;
using Pharmacy.SharedKernel.DTO;
using Pharmacy.SharedKernel.Entities;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
    public class PatientController : BaseController<Patient, CreatePatientRequest, UpdatePatientRequest>
    {
        private readonly IPatientService _patientService;
        private readonly IDiseaseService _diseaseService;
        public PatientController(IPatientService service, IMapper mapper , IDiseaseService diseaseService) : base(service, mapper)
        {
            _patientService = service;
            _diseaseService= diseaseService;
        }
       
        override public IActionResult Edit(int id)
        {
            var entity = _service.Get(id);
            return View(_mapper.Map<UpdatePatientRequest>(entity));
        }


        [HttpPost]
        override public IActionResult ApplyCreate(CreatePatientRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Invalid input or missing feild try again";
                    return RedirectToAction("Index");
                }

                
                var entity = _mapper.Map<Patient>(request);
                entity.CreatedAt = DateTime.UtcNow;
                entity.UpdatedAt = DateTime.UtcNow;
                _service.Add(entity);
                TempData["message"] = "Added successfully";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = "Error In The Adding Process";
                return RedirectToAction("Index");
            } 
        }
            
            [HttpPost]
        override public IActionResult ApplyEdit([FromForm] UpdatePatientRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["error"] = "Invalid input or missing feild try again";
                    return RedirectToAction("Index");
                }
                var entity = _mapper.Map<Patient>(request);
                var entityFromDB = _service.Get(request.Id);
                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = entityFromDB.CreatedAt;
                _service.Update(entity);
                TempData["message"] = "Updated successfully";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["error"] = "Error In The Adding Process";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Attach(int id)
        {
            var diseases = _diseaseService.GetAll();
            ViewBag.disease = new SelectList(diseases.Select(e => new
            {
                Id = e.Id,
                Name = e.Name
            }), "Id", "Name");

            ViewBag.Patient = _patientService.Get(id);
            return View("Attach", diseases);
        }

        public IActionResult GetDiseases(int id)
        {
            List<Disease> entities = _patientService.GetDiseases(id);

            return Ok(entities);
        }

        [HttpPost]
        public virtual IActionResult ApplyEventsEditing([FromRoute] int id, [FromBody] List<AttachEventDTO> eventsList)
        {
            return Ok(_patientService.ApplyEventChanges(id, eventsList));
        }


    }
}
