using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Patient
{
    public class PatientService : BaseService<Domain.Entities.Patient>, IPatientService
    {
        public PatientService(IPatientRepository repository) : base(repository)
        {
        }
    }
}
