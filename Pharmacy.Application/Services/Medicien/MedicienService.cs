using Pharmacy.Domain.Entities;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Medicien
{
    internal class MedicienService : BaseService<Domain.Entities.Medicine>, IMedicienService
    {
        public MedicienService(IRepository<Medicine> repository) : base(repository)
        {
        }
    }
}
