using DotnetBackendWithSecurityIssues.Api.Models;

namespace DotnetBackendWithSecurityIssues.Api.Database;

public interface IDbForumOperations
{
    public Task<List<IssuesDbModelForum>> GetAllEntries();
    public Task<IssuesDbModelForum> CreateEntry(IssuesDbModelForum forum);
    public Task Seed();

}