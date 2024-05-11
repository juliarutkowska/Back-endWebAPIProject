using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstProject;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LearningSourcesController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public LearningSourcesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetLearningSources()
        {
            try
            {
                var sources = await _dbContext.Sources.ToListAsync();
                return Ok(sources);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}