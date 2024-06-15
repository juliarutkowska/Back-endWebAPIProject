using Microsoft.EntityFrameworkCore;
using MyFirstProject;

namespace CodeLearningJourney.Infrastructure;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Sources> Sources { get; set; }
    public DbSet<Time> Time { get; set; }
}