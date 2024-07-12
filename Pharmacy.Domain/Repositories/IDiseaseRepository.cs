using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Domain.Repositories
{
    public interface IDiseaseRepository : IRepository<Disease>
    {
        bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList);
        public List<Medicine> GetMedicineForDisease(int id);
    }
}
