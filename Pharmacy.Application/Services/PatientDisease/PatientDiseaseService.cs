using Pharmacy.Domain.Repositories;
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
        private readonly IPatientDiseaseRepository _repository;
        public PatientDiseaseService(IPatientDiseaseRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
