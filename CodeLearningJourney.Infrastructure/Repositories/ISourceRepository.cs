using MyFirstProject;

namespace CodeLearningJourney.Infrastructure.Repositories;

public interface ISourcesRepository
{
    Task<List<Sources>> GetAllAsync();
    Task AddAsync(Sources source);
    Task UpdateAsync(Sources source);
    Task<Sources> GetByIdAsync(int id);
    Task DeleteAsync(Sources source);
}