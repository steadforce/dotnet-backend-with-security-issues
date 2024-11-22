using DotnetBackendWithSecurityIssues.Api.Options;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public static class IssuesDbContextDiExtension
{

    public static void AddIssuesDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.BindPostgresOptions(configuration);
        var postgresOptions = configuration.GetRequiredSection(PostgresOptions.OptionsKey).Get<PostgresOptions>();
        services.AddDbContext<IssuesDbContext>(
            options =>
            {
                var connectionStringBuilder = new NpgsqlConnectionStringBuilder
                {
                    Host = postgresOptions!.Hostname,
                    Port = postgresOptions.Port,
                    Database = postgresOptions.Database,
                    Username = postgresOptions.Username,
                    Password = postgresOptions.Password,

                };

                var connectionString = connectionStringBuilder.ToString();

                options.UseNpgsql(connectionString);
            });
        services.BuildServiceProvider();    
    }
}
