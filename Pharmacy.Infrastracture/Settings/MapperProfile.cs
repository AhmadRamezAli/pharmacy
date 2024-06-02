using AutoMapper;
using Pharmacy.Domain.Entities;
using Pharmacy.Infrastracture.Models;

namespace Pharmacy.Infrastracture.Settings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDAO>();
            CreateMap<CategoryDAO,Category>();
        }
    }
}
