using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Patient
{
    internal interface IPatientService : IService<Pharmacy.Domain.Entities.Patient>
    {
    }
}
