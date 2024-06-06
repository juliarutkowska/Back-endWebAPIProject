using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyFirstProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public TimeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTimes()
        {
            try
            {
                var times = await _dbContext.Time.ToListAsync();
                return Ok(times);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTime([FromBody] Time time)
        {
            try
            {
                DateTime dateOfTimeAdded = time.DateColumn;
                _dbContext.Time.Add(time);
                await _dbContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTimes), new { id = time.Id }, time);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTime(int id, [FromBody] Time time)
        {
            try
            {
                if (id != time.Id)
                {
                    return BadRequest("Id mismatch");
                }

                _dbContext.Entry(time).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTime(int id)
        {
            try
            {
                var time = await _dbContext.Time.FindAsync(id);
                if (time == null)
                {
                    return NotFound();
                }

                _dbContext.Time.Remove(time);
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