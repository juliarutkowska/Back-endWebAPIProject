﻿using Microsoft.EntityFrameworkCore;
using MyFirstProject;

namespace CodeLearningJourney.Infrastructure.Repositories;

public class SourcesRepository : ISourcesRepository
{
    private readonly MyDbContext _context;

    public SourcesRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sources>> GetAllAsync()
    {
        return await _context.Sources.ToListAsync();
    }

    public async Task AddAsync(Sources source)
    {
        _context.Sources.Add(source);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sources source)
    {
        _context.Entry(source).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Sources> GetByIdAsync(int id)
    {
        return await _context.Sources.FindAsync(id);
    }

    public async Task DeleteAsync(Sources source)
    {
        _context.Sources.Remove(source);
        await _context.SaveChangesAsync();
    }
}