using Microsoft.EntityFrameworkCore;

using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}