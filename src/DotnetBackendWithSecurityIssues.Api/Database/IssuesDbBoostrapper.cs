using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using DotnetBackendWithSecurityIssues.Api.Service;
using DotnetBackendWithSecurityIssues.Api.Utils;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public class IssuesDbBoostrapper
{
    public static async Task UpdateDatabaseAsync(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        // Migration
        using var context = serviceScope.ServiceProvider.GetRequiredService<IssuesDbContext>();
        context.Database.Migrate();

        // Clean db and seed data
        context.IssuesDbModelForum.RemoveRange(context.IssuesDbModelForum);
        var listData = await SeedingData.GetSedingDataAsync();
        List<ForumIssuesDbModel> listDbData = listData.Select(x => new ForumIssuesDbModel
        {
            Title = x.Title,
            Content = x.Content
        }).ToList();

        await context.IssuesDbModelForum.AddRangeAsync(listDbData);
        await context.SaveChangesAsync();
    }
}
