using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public static class IssuesDbContextDiExtension
{

  public static void AddIssuesDatabase(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<IssuesDbContext>(
        options =>
        {
          var port = configuration.GetValue<int>("PSQL_DB_PORT");
          if (port <= 0)
          {
            throw new ArgumentException("Invalid port number. Port must be greater than 0.");
          }
          var connectionStringBuilder = new NpgsqlConnectionStringBuilder
          {
            Host = configuration.GetValue<string>("PSQL_DB_HOSTNAME"),
            Port = port,
            Database = configuration.GetValue<string>("PSQL_DB_DATABASE"),
            Username = configuration.GetValue<string>("PSQL_DB_USERNAME"),
            Password = configuration.GetValue<string>("PSQL_DB_PASSWORD")

          };

          var connectionString = connectionStringBuilder.ToString();

          options.UseNpgsql(connectionString);
        });
    services.BuildServiceProvider();
  }
}
