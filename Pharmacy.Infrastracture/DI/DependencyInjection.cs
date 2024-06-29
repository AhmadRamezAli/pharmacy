﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;

namespace Pharmacy.Infrastracture.DI;

public static class DependencyInjection
{
  
    public static void AddInfrastructure(this IServiceCollection services, string conncetionString)
    {
       
        services.AddDbContext<PharmacyContext>(options =>
        {
            options.UseSqlServer(conncetionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

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
        
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<PharmacyContext>();
    }
    
}
