using Microsoft.EntityFrameworkCore;

using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Data
{
    public class HealthMateDbContext : DbContext
    {
        public HealthMateDbContext(DbContextOptions<HealthMateDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        //public DbSet<HealthRecords> {get;set;}

    }
}