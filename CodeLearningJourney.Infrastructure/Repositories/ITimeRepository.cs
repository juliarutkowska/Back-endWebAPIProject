namespace CodeLearningJourney.Infrastructure.Repositories;

public interface ITimeRepository
{
    Task<List<Time>> GetAllAsync();
    Task AddAsync(Time hours);
    Task UpdateAsync(Time hours);
    Task<Time> GetByIdAsync(int id);
    Task DeleteAsync(Time hours);
}