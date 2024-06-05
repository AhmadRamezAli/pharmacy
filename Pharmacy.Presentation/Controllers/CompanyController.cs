using AutoMapper;
using Pharmacy.Application.Services.Company;
using Pharmacy.Domain.Entities;
using Pharmacy.Presentation.Models.Company;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Presentation.Controllers
{
	public class CompanyController : BaseController<Company, CreateCompanyRequest, UpdateCompanyReques>
	{
		public CompanyController(ICompanyService service, IMapper mapper) : base(service, mapper)
		{
		}
	}
}
