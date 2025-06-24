using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using DotnetBackendWithSecurityIssues.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBackendWithSecurityIssues.Api.Controllers
{

  [ApiController]
  [Route("Api/[controller]")]
  public class IssuesForumController : ControllerBase
  {
    private readonly ILogger<IssuesForumController> _logger;
    private readonly IIssuesForumOperations _dbForumOperations;

    public IssuesForumController(
        ILogger<IssuesForumController> logger,
        IIssuesForumOperations dbForumOperations)
    {
      _logger = logger;
      _dbForumOperations = dbForumOperations;
    }

    /// <summary>
    ///  Saves a new forum entry to the database.
    /// </summary> 
    ///<response code="200">Entry was saved successfully</response>
    ///<response code="500">An internal error has occurred. See server log</response>
    [HttpPost("SaveEntry")]
    public async Task<IActionResult> PostEntryAsync([FromBody] ForumRequestObject entry)
    {
      try
      {
        var result = await _dbForumOperations.CreateEntry(entry);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error while saving forum entry");
        return StatusCode(500, "Internal server error while saving entry");

      }
    }

    /// <summary>
    ///  Returns all forum entries in reverse order (newest first).
    /// </summary>
    /// <returns code="200">Json object with db entries</returns>
    /// ///<response code="500">An internal error has occurred. See server log</response>
    [HttpGet("GetAllEntries")]
    public async Task<IActionResult> GetAllEntries()
    {
      try
      {
        var forumEntries = await _dbForumOperations.GetAllEntries();
        forumEntries.Reverse();
        return Ok(forumEntries);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error while retrieving forum entries");
        return StatusCode(500, "Internal server error while retrieving entries");
      }
    }

    /// <summary>
    ///  Reset the database to the initial state with seeded data.
    /// </summary>
    /// <returns code="200">Reset was successful</returns>
    ///<response code="500">An internal error has occurred. See server log</response>
    [HttpGet("Reset")]
    public async Task<IActionResult> Reset()
    {
      try
      {
        await _dbForumOperations.SeedAsync();
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error while resetting the database");
        return StatusCode(500, "Internal server error while resetting the database");

      }
    }
  }
}
