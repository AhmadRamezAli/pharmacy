using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Patient
{
    internal class PatientService : BaseService<Domain.Entities.Patient>, IPatientService
    {
        public PatientService(IRepository<Domain.Entities.Patient> repository) : base(repository)
        {
        }
    }
}
