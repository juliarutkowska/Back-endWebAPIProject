namespace MyFirstProject.Repositories;
using MyFirstProject;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITimeRepository
{
    Task<List<Time>> GetAllAsync();
    Task AddAsync(Time time);
    Task UpdateAsync(Time time);
    Task<Time> GetByIdAsync(int id);
    Task DeleteAsync(Time time);
}