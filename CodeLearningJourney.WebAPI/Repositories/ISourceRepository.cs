namespace MyFirstProject.Repositories;
using MyFirstProject;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISourcesRepository
{
    Task<List<Sources>> GetAllAsync();
    Task AddAsync(Sources source);
    Task UpdateAsync(Sources source);
    Task<Sources> GetByIdAsync(int id);
    Task DeleteAsync(Sources source);
}