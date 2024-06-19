using Microsoft.EntityFrameworkCore;

namespace CodeLearningJourney.Infrastructure.Repositories;

public class TimeRepository : ITimeRepository
{
    private readonly MyDbContext _context;

    public TimeRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Time>> GetAllAsync()
    {
        return await _context.Time.ToListAsync();
    }

    public async Task AddAsync(Time hours)
    {
        _context.Time.Add(hours);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Time hours)
    {
        _context.Entry(hours).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Time> GetByIdAsync(int id)
    {
        return await _context.Time.FindAsync(id);
    }

    public async Task DeleteAsync(Time hours)
    {
        _context.Time.Remove(hours);
        await _context.SaveChangesAsync();
    }
}