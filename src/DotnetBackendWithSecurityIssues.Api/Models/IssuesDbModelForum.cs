namespace DotnetBackendWithSecurityIssues.Api.Models;

public class IssuesDbModelForum
{
    public long Id { get; private set; }

    public string Title { get; set; } = null!;

    public string Content { get; private set; } = null!;
}
