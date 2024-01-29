using BlobStorage.Database.Interfaces;
using BlobStorage.Database;
using Microsoft.EntityFrameworkCore;
using BlobStorage.API.Service.Interfaces;
using BlobStorage.API.Service;
using BlobStorage.Database.Settings;
using Microsoft.Extensions.Configuration;
using BlobStorage.API.Configuration;
using Microsoft.Extensions.Options;

namespace BlobStorage.API
{
    /// <summary>
    /// IServiceCollection Extension
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds API related services, basic are controllers, endpoints, swagger.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>Configured service container</returns>
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        /// <summary>
        /// Adds business logic services for API.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>Configured service container</returns>
        public static IServiceCollection AddServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            var azureSettings = new AzureBlobConfig();
            configuration.Bind(AzureBlobConfig.SectionName, azureSettings);

            services.AddSingleton(Options.Create(azureSettings));
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
