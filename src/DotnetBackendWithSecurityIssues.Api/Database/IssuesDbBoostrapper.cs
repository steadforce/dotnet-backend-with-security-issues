using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public class IssuesDbBoostrapper
{
    public static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<IssuesDbContext>();
        context.Database.Migrate();
    }
}
