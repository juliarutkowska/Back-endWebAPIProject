namespace MyFirstProject.Repositories;

using Microsoft.EntityFrameworkCore;
using MyFirstProject;
using System.Collections.Generic;
using System.Threading.Tasks;

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

    public async Task AddAsync(Time time)
    {
        _context.Time.Add(time);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Time time)
    {
        _context.Entry(time).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Time> GetByIdAsync(int id)
    {
        return await _context.Time.FindAsync(id);
    }

    public async Task DeleteAsync(Time time)
    {
        _context.Time.Remove(time);
        await _context.SaveChangesAsync();
    }
}