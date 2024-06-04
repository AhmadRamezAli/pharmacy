using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Ingredient
{
    internal class IngredientService : BaseService<Domain.Entities.Ingredient>, IIngredientService
    {
        public IngredientService(IIngredientRepository repository) : base(repository)
        {
        }
    }
}
