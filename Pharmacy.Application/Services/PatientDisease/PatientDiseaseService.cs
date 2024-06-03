using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.PatientDisease
{
    public class PatientDiseaseService : BaseService<Domain.Entities.PatientDisease>, IPatientDiseaseService
    {
        public PatientDiseaseService(IRepository<Domain.Entities.PatientDisease> repository) : base(repository)
        {
        }
    }
}
