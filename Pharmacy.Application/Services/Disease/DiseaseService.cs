using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Disease
{
    internal class DiseaseService : BaseService<Domain.Entities.Disease>, IDiseaseService
    {
        public DiseaseService(IRepository<Domain.Entities.Disease> repository) : base(repository)
        {
        }
    }
}
