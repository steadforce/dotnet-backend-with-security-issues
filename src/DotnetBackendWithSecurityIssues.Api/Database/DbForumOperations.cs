using DotnetBackendWithSecurityIssues.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public class DbForumOperations : IDbForumOperations
{
    private readonly IssuesDbContext _context;

    public DbForumOperations(IssuesDbContext context)
    {
        _context = context;
    }

    public async Task<List<IssuesDbModelForum>> GetAllEntries()
    {
        if(!_context.IssuesDbModelForum.Any())
        {
            await Seed();
        }
        return await _context.IssuesDbModelForum.ToListAsync();
    }

    public async Task<IssuesDbModelForum> CreateEntry(IssuesDbModelForum forum)
    {
        _context.IssuesDbModelForum.Add(forum);
        await _context.SaveChangesAsync();
        return forum;
    }

    public async Task Seed()
    {
        await DeleteData();
        await GetSedingDataAsync().ContinueWith(async task =>
        {
            var issuesList = task.Result;
            await _context.IssuesDbModelForum.AddRangeAsync(issuesList);
            await _context.SaveChangesAsync();
        });
    }

    private async Task DeleteData()
    {
        _context.IssuesDbModelForum.RemoveRange(_context.IssuesDbModelForum);
        await _context.SaveChangesAsync();
    }

    private static async Task<List<IssuesDbModelForum>> GetSedingDataAsync()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "SeedDataForum.json");
        List<IssuesDbModelForum> issuesList = [];

        if (File.Exists(filePath))
        {
            var jsonData = await File.ReadAllTextAsync(filePath);

            issuesList = JsonSerializer.Deserialize<List<IssuesDbModelForum>>(jsonData) ?? [];
        }

        return issuesList;
    }
}
