using Pharmacy.Domain.DTOs;
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
        private readonly IPatientRepository _repository;
        public PatientService(IPatientRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList)
        {
            return _repository.ApplyEventChanges(id, eventsList);
        }

        public List<Domain.Entities.Disease> GetDiseases(int id)
        {
            return _repository.GetDiseases(id);
        }
    }
}
