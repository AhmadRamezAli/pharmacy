using AutoMapper;
using Pharmacy.Application.Services;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
    public class MedicineController : BaseController<Medicine, CreateMedicineRequest, UpdateMedicineRequest>
    {
        public MedicineController(BaseService<Medicine> service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
