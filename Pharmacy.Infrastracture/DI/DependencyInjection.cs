using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Repositories;
using Pharmacy.Infrastracture.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastracture.DI;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, string conncetionString)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
        services.AddDbContext<PharmacyContext>(options =>
        {
            options.UseSqlServer(conncetionString);
        });
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        services.AddScoped<ICompanyRepository, CompanyRepository>();

        services.AddScoped<IDiseaseMedicineRepository, DiseaseMedicineRepository>();

        services.AddScoped<IDiseaseRepository, DiseaseRepository>();

        services.AddScoped<IIngredientRepository, IngredientRepository>();

        services.AddScoped<IMedicienIngredientRepository, MedicienIngredientRepository>();

        services.AddScoped<IMedicineRepository, MedicineRepository>();

        services.AddScoped<IPatientDiseaseRepository, PatientDiseaseRepository>();

        services.AddScoped<IPatientRepository, PatientRepository>();
    }
}
