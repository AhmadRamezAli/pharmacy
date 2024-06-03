using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.DiseaseMedicine
{
    public class DiseaseMedicineService : BaseService<Domain.Entities.DiseaseMedicine>, IDiseaseMedicineService
    {
        public DiseaseMedicineService(IRepository<Domain.Entities.DiseaseMedicine> repository) : base(repository)
        {
        }
    }
}
