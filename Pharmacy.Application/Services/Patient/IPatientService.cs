using Pharmacy.Domain.DTOs;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Patient
{
    public interface IPatientService : IService<Pharmacy.Domain.Entities.Patient>
    {
        bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList);
        List<Domain.Entities.Disease> GetDiseases(int id);
    }
}
