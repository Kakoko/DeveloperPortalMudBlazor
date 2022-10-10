using Stango.Shared.Models;

namespace Stango.Server.Data.Repositories
{
    public interface IDeveloperRepository
    {
        public Task<List<Developer>> GetDevelopers(); 
        public Task<Developer> GetDeveloper(Guid id);
        public Task AddDeveloper(Developer developer);
        public Task DeleteDeveloper(Guid id);
        public Task UpdateDeveloper(Developer developer);
    }
}
