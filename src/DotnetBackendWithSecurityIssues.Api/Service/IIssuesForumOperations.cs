using DotnetBackendWithSecurityIssues.Api.Models.Forum;

namespace DotnetBackendWithSecurityIssues.Api.Service;

public interface IIssuesForumOperations
{
    public Task<IEnumerable<ForumIssuesDbModel>> GetAllEntries();
    public Task<int> CreateEntry(ForumRequestObject forum);
    public Task Seed();
}