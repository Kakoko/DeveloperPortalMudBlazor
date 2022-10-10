using Stango.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Stango.Server.Data.Contexts
{
    public class DeveloperDbContext : DbContext
    {
        public DeveloperDbContext(DbContextOptions<DeveloperDbContext> options):
            base(options)
        
        {

        }


        public DbSet<Developer> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().
                HasData(
                new Developer() { Id = Guid.NewGuid(), Company = "Microsoft", Email = "codefather@code.com", UserName = "CodeFather" },
                new Developer() { Id = Guid.NewGuid(), Company = "CodeUnparalled", Email = "chiefscientist@code.com", UserName = "ChiefScientist" });
        }
    }
}
