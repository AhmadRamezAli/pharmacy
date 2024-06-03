using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Disease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
    internal class DiseaseController : BaseController<Disease, CreateDisaseRequest, UpdateDiseaseRequest>
    {
        public DiseaseController(BaseService<Disease> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
