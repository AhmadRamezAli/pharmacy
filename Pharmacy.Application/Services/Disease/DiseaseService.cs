using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Disease
{
    public class DiseaseService : BaseService<Domain.Entities.Disease>, IDiseaseService
    {
        public DiseaseService(IDiseaseRepository repository) : base(repository)
        {
            _repository = repository;
        }
        private readonly IDiseaseRepository _repository;

        public List<Domain.Entities.Medicine> GetMedicineForDisease(int id)
        {
           return _repository.GetMedicineForDisease(id);
        }

        public bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList)
        {
            return _repository.ApplyEventChanges(id, eventsList);
        }
    }
}
