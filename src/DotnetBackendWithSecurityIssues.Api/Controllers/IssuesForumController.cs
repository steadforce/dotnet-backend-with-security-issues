using DotnetBackendWithSecurityIssues.Api.Database;
using Microsoft.AspNetCore.Mvc;

namespace DotnetBackendWithSecurityIssues.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuesForumController : ControllerBase
    {        
        private readonly ILogger<IssuesForumController> _logger;
        private readonly IDbForumOperations _dbForumOperations;

        public IssuesForumController(
            ILogger<IssuesForumController> logger,
            IDbForumOperations dbForumOperations)
        {
            _logger = logger;
            _dbForumOperations = dbForumOperations;
        }

        [HttpGet("/Get")]
        public void Get(HttpGetAttribute httpGetAttribute)
        {
            
        }

        [HttpPost("/Post")]
        public void Post(HttpPostAttribute httpPostAttribute)
        {

        }

        [HttpGet("/GetAllEntries")]
        public async Task<IActionResult> GetAllEntries()
        {
            var forumEntries = await _dbForumOperations.GetAllEntries();
            return Ok(forumEntries);
        }

        [HttpGet("/Reset")]
        public async Task Reset()
        {
            await _dbForumOperations.Seed();
        }
    }
}
