using AutoMapper;
using Pharmacy.Domain.Entities;
using Pharmacy.Infrastracture.Models;

namespace Pharmacy.Adapters.Settings;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category, CategoryDAO>();
        CreateMap<CategoryDAO, Category>();

        CreateMap<Company, CompanyDAO>();
        CreateMap<CompanyDAO, Company>();

        CreateMap<Disease, DiseaseDAO>();
        CreateMap<DiseaseDAO, Disease>();

        CreateMap<DiseaseMedicine, DiseaseMedicineDAO>();
        CreateMap<DiseaseMedicineDAO, DiseaseMedicine>();

        CreateMap<Ingredient, IngredientDAO>();
        CreateMap<IngredientDAO, Ingredient>();

        CreateMap<MedicienIngredient, MedicienIngredientDAO>();
        CreateMap<MedicienIngredientDAO, MedicienIngredient>();

        CreateMap<Medicine, MedicineDAO>();
        CreateMap<MedicineDAO, Medicine>();

        CreateMap<Patient, PatientDAO>();
        CreateMap<PatientDAO, Patient>();

        CreateMap<PatientDisease, PatientDiseaseDAO>();
        CreateMap<PatientDiseaseDAO, PatientDisease>();
    }
}
