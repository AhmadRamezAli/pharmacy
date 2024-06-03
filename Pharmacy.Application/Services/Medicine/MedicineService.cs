using Pharmacy.Domain.Entities;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Medicine
{
    public class MedicineService : BaseService<Domain.Entities.Medicine>, IMedicineService
    {
        public MedicineService(IRepository<Domain.Entities.Medicine> repository) : base(repository)
        {
        }
    }
}
