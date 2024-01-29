using AgeCalculator.Services;
using AgeCalculator.Services.Interfaces;

namespace AgeCalculator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICalculatorService, CalculatorService>();

            return services;
        }
    }
}
