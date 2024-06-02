using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Application.Services.Category;

namespace Pharmacy.Application.DI;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
    }
}
