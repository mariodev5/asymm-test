using Microsoft.EntityFrameworkCore;
using AysmmTest.WebAPI.Entities;

namespace AysmmTest.WebAPI.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
    }
}
