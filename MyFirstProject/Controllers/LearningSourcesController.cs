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
        
        [HttpPost]
        public async Task<IActionResult> AddLearningSource([FromBody] Sources source)
        {
            try
            {
                _dbContext.Sources.Add(source);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetLearningSources), new { id = source.Id }, source);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLearningSource(int id, [FromBody] Sources source)
        {
            try
            {
                if (id != source.Id)
                {
                    return BadRequest("Id mismatch");
                }

                _dbContext.Entry(source).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningSource(int id)
        {
            try
            {
                var source = await _dbContext.Sources.FindAsync(id);
                if (source == null)
                {
                    return NotFound();
                }

                _dbContext.Sources.Remove(source);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}