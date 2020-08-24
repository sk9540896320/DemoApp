namespace DemoApp.Service.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Defines the <see cref="ServicesConfiguration" />.
    /// </summary>
    public static class ServicesConfiguration
    {
        /// <summary>
        /// The ConfigureClientServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureClientServices(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var applicationOptions = serviceProvider.GetRequiredService<ApplicationOptions>();
            return services
                .ConfigureDbServices(applicationOptions.ConnectionString, applicationOptions.ReadOnlyConnectionString)
                .ConfigureBusinessServices();
        }

        /// <summary>
        /// The ConfigureSwagger.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            var swaggerAssemblies = new[] { typeof(Program).Assembly, typeof(ContactCreateModel).Assembly, typeof(Model).Assembly };
            services.AddSwaggerWithComments(ApiConstants.ApiName, ApiConstants.ApiVersion, swaggerAssemblies);
            services.AddSwaggerWithComments(ApiConstants.JobsApiName, ApiConstants.JobsApiVersion, swaggerAssemblies);
            return services;
        }

        /// <summary>
        /// The ConfigureDomainApis.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureDomainApis(this IServiceCollection services)
        {
            services.ConfigureSecurityServices();
            var serviceProviderOption = services.BuildServiceProvider();
            var applicationOptions = serviceProviderOption.GetRequiredService<ApplicationOptions>();
            services.AddTransient<IDemoUserClient>((serviceProvider) =>
            {
                var instance = new DemoUserClient(applicationOptions.UserServiceBaseUri.OriginalString, new System.Net.Http.HttpClient());
                return instance;
            });
            return services;
        }

        /// <summary>
        /// The ConfigureCustomMiddleware.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection ConfigureTenantIdMiddleware(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ITenantIdProvider, TenantIdProvider>();
            services.AddScoped<ITenantIdService, TenantIdService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserServiceProvider, UserServiceProvider>();
            return services;
        }
    }
}
