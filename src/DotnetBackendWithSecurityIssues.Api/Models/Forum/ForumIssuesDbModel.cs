namespace DotnetBackendWithSecurityIssues.Api.Models.Forum;

public class ForumIssuesDbModel
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
