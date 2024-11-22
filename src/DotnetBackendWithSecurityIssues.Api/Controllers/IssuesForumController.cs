using DotnetBackendWithSecurityIssues.Api.Models.Forum;
using DotnetBackendWithSecurityIssues.Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBackendWithSecurityIssues.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("/SaveEntry")]
        public async Task<IActionResult> PostEntryAsync([FromBody] ForumRequestObject entry)
        {
            var result = await _dbForumOperations.CreateEntry(entry);
            return Ok();
        }

        [HttpGet("/GetAllEntries")]
        public async Task<IActionResult> GetAllEntries()
        {
            var forumEntries = await _dbForumOperations.GetAllEntries();
            forumEntries.Reverse();
            return Ok(forumEntries);
        }

        [HttpGet("/Reset")]
        public async Task<IActionResult> Reset()
        {
            await _dbForumOperations.Seed();
            return Ok();
        }
    }
}
