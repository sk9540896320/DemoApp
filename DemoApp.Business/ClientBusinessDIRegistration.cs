namespace Demo.User.Business
{
    using DemoApp.Business.Group;
    using DemoApp.Business.Group.Manager;

    /// <summary>
    /// Defines the <see cref="ClientBusinessDIRegistration" />.
    /// </summary>
    public static class ClientBusinessDIRegistration
    {
        /// <summary>
        /// The ConfigureBusinessServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GroupMappingProfile).Assembly);
            services.AddManagers(typeof(GroupQueryManager).Assembly);

            services.AddScoped<IBlobManager, BlobManager>();
            return services;
        }
    }
}
