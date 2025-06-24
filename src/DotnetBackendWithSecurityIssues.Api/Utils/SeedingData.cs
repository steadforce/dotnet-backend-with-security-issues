using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using System.Text.Json;

namespace DotnetBackendWithSecurityIssues.Api.Utils;

public static class SeedingData
{
  public static async Task<List<ForumRequestObject>> GetSedingDataAsync()
  {
    string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "SeedDataForum.json");
    List<ForumRequestObject> issuesList = [];

    if (File.Exists(filePath))
    {
      var jsonData = await File.ReadAllTextAsync(filePath);

      var options = new JsonSerializerOptions
      {
        PropertyNameCaseInsensitive = true
      };
      issuesList = JsonSerializer.Deserialize<List<ForumRequestObject>>(jsonData, options) ?? [];
    }
    return issuesList;
  }
}
