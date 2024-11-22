namespace DotnetBackendWithSecurityIssues.Api.Models.Forum;

public class ForumIssuesDbModel
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}
