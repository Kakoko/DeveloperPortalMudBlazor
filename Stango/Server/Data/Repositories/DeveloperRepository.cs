using Stango.Server.Data.Contexts;
using Stango.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Stango.Server.Data.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly DeveloperDbContext _developerDbContext;

        public DeveloperRepository(DeveloperDbContext developerDbContext)
        {
            _developerDbContext = developerDbContext ?? throw new ArgumentNullException(nameof(developerDbContext));
        }
        public async Task AddDeveloper(Developer developer)
        {
            try
            {
                developer.Id = Guid.NewGuid();
                _developerDbContext.Developers.Add(developer);
                _developerDbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Failed to create developer");
            }
        }

        public async Task DeleteDeveloper(Guid id)
        {
            try
            {
                var developer = await _developerDbContext.Developers.FirstOrDefaultAsync(u => u.Id == id);
                if (developer != null)
                {
                    _developerDbContext.Developers.Remove(developer);
                    _developerDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("Developer does not exist");
                }
            }
            catch (Exception)
            {

                throw new Exception("Failed to delete developer");
            }
        }

        public async Task<Developer> GetDeveloper(Guid id)
        {
            try
            {
                var developer = await _developerDbContext.Developers.FirstOrDefaultAsync(u => u.Id == id);
                if(developer != null)
                {
                    return developer;
                }
                else
                {
                    throw new ArgumentNullException("Failed to find developer");
                }

            }
            catch (Exception)
            {

                throw new Exception("Failed to get developer");
            }
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            try
            {
                var developers = await _developerDbContext.Developers.ToListAsync();
                return developers;
            }
            catch (Exception)
            {

                throw new Exception("Failed to get developers");
            }
        }

        public async Task UpdateDeveloper(Developer developer)
        {
            try
            {
                var developerToEdit = await _developerDbContext.Developers.FirstOrDefaultAsync(u => u.Id == developer.Id);
                if(developerToEdit != null)
                {
                   
                    developerToEdit.UserName = developer.UserName;
                    developerToEdit.Email = developer.Email;
                    developerToEdit.Company = developer.Company;

                    _developerDbContext.Developers.Update(developerToEdit);
                    _developerDbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("Developer not found");
                }
            }
            catch (Exception)
            {

                throw new Exception("Faled to update developer");
            }
        }
    }
}
