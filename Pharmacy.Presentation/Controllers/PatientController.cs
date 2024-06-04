using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Patient;
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
        public PatientController(IPatientService service, IMapper mapper) : base(service, mapper)
        {
        }
        override public IActionResult Create()
        {
            return View();
        }

        override public IActionResult Edit(int id)
        {
            var entity = _service.Get(id);
            return View(_mapper.Map<UpdatePatientRequest>(entity));
        }


        [HttpPost]
        override public IActionResult ApplyCreate(CreatePatientRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }

            var entity = _mapper.Map<Patient>(request);
            entity.CreatedAt=DateTime.UtcNow;
            entity.UpdatedAt=DateTime.UtcNow;
            _service.Add(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        override public IActionResult ApplyEdit([FromForm] UpdatePatientRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var entity = _mapper.Map<Patient>(request);
            var entityFromDB = _service.Get(request.Id);
            entity.UpdatedAt=DateTime.UtcNow;
            entity.CreatedAt=entityFromDB.CreatedAt;
            _service.Update(entity);
            return RedirectToAction(nameof(this.Index));
        }





    }
}
