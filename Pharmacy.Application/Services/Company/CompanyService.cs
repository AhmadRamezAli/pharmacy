using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Company
{
    public class CompanyService : BaseService<Domain.Entities.Company>, ICompanyService
    {
        public CompanyService(ICompanyRepository repository) : base(repository)
        {
        }
    }
}
