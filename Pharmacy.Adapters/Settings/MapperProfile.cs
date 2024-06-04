using AutoMapper;
using Pharmacy.Domain.Entities;
using Pharmacy.Infrastracture.Models;
using Pharmacy.Presentation.Controllers;
using Pharmacy.Presentation.Models.Category;
using Pharmacy.Presentation.Models.Company;
using Pharmacy.Presentation.Models.Disease;
using Pharmacy.Presentation.Models.Medicine;
using Pharmacy.Presentation.Models.Patient;

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

        // 

        CreateMap<CreateCategoryRequest, Category>();
        CreateMap<UpdateCategoryRequest, Category>();
        CreateMap<Category,UpdateCategoryRequest>();
        CreateMap<Category,CreateCategoryRequest>();
        //

        CreateMap<CreateCompanyRequest,Company>();
        CreateMap<UpdateCompanyReques, Company>();
        CreateMap<Company,CreateCompanyRequest>();
        CreateMap<Company,UpdateCompanyReques>();
        //

        CreateMap<CreateMedicineRequest, Medicine>();
        CreateMap<UpdateMedicineRequest, Medicine>();
        CreateMap<Medicine,CreateMedicineRequest>();
        CreateMap<Medicine,UpdateMedicineRequest>();

        //
        CreateMap<CreatePatientRequest, Patient>();
        CreateMap<UpdatePatientRequest, Patient>();
        CreateMap<Patient,CreatePatientRequest>();
		CreateMap<Patient, UpdatePatientRequest>();
        //


        CreateMap<CreateDiseaseRequest,Disease>();
        CreateMap<UpdateDiseaseRequest,Disease>();
        CreateMap<Disease,CreateDiseaseRequest>();
        CreateMap<Disease,UpdateDiseaseRequest>();

    }
}
