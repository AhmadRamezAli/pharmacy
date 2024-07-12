using Pharmacy.Domain.DTOs;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Disease
{
    public interface IDiseaseService : IService<Pharmacy.Domain.Entities.Disease>
    {
        bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList);
        public List<Pharmacy.Domain.Entities.Medicine> GetMedicineForDisease(int id);
    }
}
