namespace DemoApp.DataAccess
{
    using Demo.Framework.DataAccess;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DemoApp.DataAccess.Repository;

    public static class ClientDbDIRegistration
    {
        /// <summary>
        /// Configures the client db context services.
        /// </summary>
        /// <param name="services">A <see cref="IServiceCollection"/> to add the client services to.</param>
        /// <param name="configuration">A <see cref="IConfiguration"/> with the client configuration.</param>
        public static IServiceCollection ConfigureDbServices(this IServiceCollection services, string connectionString, string readOnlyConnectionString)
        {
            services.AddDbContext<DemoDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddDbContext<DemoReadOnlyDbContext>(options => options.UseSqlServer(readOnlyConnectionString), ServiceLifetime.Scoped);
            services.AddRepositories(typeof(GroupQueryRepository).Assembly);
            return services;
        }
    }
}
