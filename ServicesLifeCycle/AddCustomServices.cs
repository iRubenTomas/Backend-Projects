using ExploreTheProgramCsFile.NewFolder;
using ExploreTheProgramCsFile.Scoped;
using ExploreTheProgramCsFile.Singleton;

namespace ExploreTheProgramCsFile
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Services Life cycle -> Add services to the DI container.
            services.AddTransient<ITransientService, TransientService>();
            services.AddScoped<IScopedService, ScopedService>();
            services.AddSingleton<ISingletonService, SingletonService>();

            return services;
        }
    }
}
