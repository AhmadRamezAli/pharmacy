using Microsoft.Extensions.DependencyInjection;
using Pharmacy.Adapters.Settings;


namespace Pharmacy.Adapters.DI;

public static class DependencyInjection
{
    public static void AddAdapters(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);

    }
}

