using DotnetBackendWithSecurityIssues.Api.Database;
using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using DotnetBackendWithSecurityIssues.Api.Utils;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackendWithSecurityIssues.Api.Service;

public class IssuesForumOperations : IIssuesForumOperations
{
  private readonly IssuesDbContext _context;
  private static readonly SemaphoreSlim _seedLock = new(1, 1);

  public IssuesForumOperations(IssuesDbContext context)
  {
    _context = context;
  }

  public async Task<List<ForumIssuesDbModel>> GetAllEntries()
  {
    if (!_context.IssuesDbModelForum.Any())
    {
      await SeedAsync();
    }
    return await _context.IssuesDbModelForum.ToListAsync();
  }

  public async Task<int> CreateEntry(ForumRequestObject forum)
  {
    var newDBEntry = new ForumIssuesDbModel
    {
      Title = forum.Title,
      Content = forum.Content
    };

    _context.IssuesDbModelForum.Add(newDBEntry);
    var result = await _context.SaveChangesAsync();
    return result;
  }

  public async Task SeedAsync()
  {
    await _seedLock.WaitAsync();
    try
    {
      await DeleteDataAsync();
      var listData = await SeedingData.GetSedingDataAsync();

      var listDbData = listData.Select(x => new ForumIssuesDbModel
      {
        Title = x.Title,
        Content = x.Content
      }).ToList();

      await _context.IssuesDbModelForum.AddRangeAsync(listDbData);
      await _context.SaveChangesAsync();
    }
    finally
    {
      _seedLock.Release();
    }
  }

  private async Task DeleteDataAsync()
  {
    _context.IssuesDbModelForum.RemoveRange(_context.IssuesDbModelForum);
    await _context.SaveChangesAsync();
  }
}
