using BlobStorage.Database.Interfaces;
using BlobStorage.Database.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlobStorage.Database
{
    /// <summary>
    /// IService extension
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds database services. Configure connection
        /// </summary>
        /// <param name="services">Service container</param>
        /// <param name="configuration">Configuration, used for retrieving data from appsettings</param>
        /// <returns>Configured database service</returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, ConfigurationManager configuration)
        {
            var dbSettings = new DatabaseConfig();
            configuration.Bind(DatabaseConfig.SectionName, dbSettings);

            services.AddDbContext<IDatabaseContext, DatabaseContext>(options => options.UseSqlServer(dbSettings.DbConnectionString));
            return services;
        }
    }
}
