using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
    public class PatientController : BaseController<Patient, CreatePatientRequest, UpdatePatientRequest>
    {
        public PatientController(BaseService<Patient> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
