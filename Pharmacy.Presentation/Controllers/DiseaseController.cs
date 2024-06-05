using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Disease;
using Pharmacy.Domain.Entities;
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
        public DiseaseController(IDiseaseService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
