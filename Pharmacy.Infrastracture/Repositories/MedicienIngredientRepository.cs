using AutoMapper;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastracture.Repositories
{
    public class MedicienIngredientRepository : BaseRepository<MedicienIngredient, MedicienIngredientDAO>, IMedicienIngredientRepository
    {
        public MedicienIngredientRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
