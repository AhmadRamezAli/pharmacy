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
    internal class DiseaseRepository : BaseRepository<Disease, DiseaseDAO>, IDiseaseRepository
    {
        public DiseaseRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
