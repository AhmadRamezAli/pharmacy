using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.MedicienIngredient
{
    internal class MedicienIngredientService : BaseService<Domain.Entities.MedicienIngredient>, IMedicienIngredientService
    {
        public MedicienIngredientService(IMedicienIngredientRepository repository) : base(repository)
        {
        }
    }
}
