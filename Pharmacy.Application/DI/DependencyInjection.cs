using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Services.Category;
using Pharmacy.Application.Services.Company;
using Pharmacy.Application.Services.Disease;
using Pharmacy.Application.Services.DiseaseMedicine;
using Pharmacy.Application.Services.Ingredient;
using Pharmacy.Application.Services.MedicienIngredient;
using Pharmacy.Application.Services.Medicine;
using Pharmacy.Application.Services.Patient;
using Pharmacy.Application.Services.PatientDisease;

namespace Pharmacy.Application.DI;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();

        services.AddScoped<ICompanyService, CompanyService>();

        services.AddScoped<IDiseaseService, DiseaseService>();

        services.AddScoped<IDiseaseMedicineService, DiseaseMedicineService>();

        services.AddScoped<IIngredientService, IngredientService>();

        services.AddScoped<IMedicineService,MedicineService>();

        services.AddScoped<IMedicienIngredientService, MedicienIngredientService>();

        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<IPatientDiseaseService, PatientDiseaseService>();
    }
}
