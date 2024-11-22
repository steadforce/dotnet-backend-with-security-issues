namespace DotnetBackendWithSecurityIssues.Api.Options
{
    public static class BindOptionsDiExtension
    {
        public static IServiceCollection BindPostgresOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresSection = configuration.GetRequiredSection(PostgresOptions.OptionsKey);
            services.AddOptions<PostgresOptions>()
                .Bind(postgresSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services;
        }
    }
}
