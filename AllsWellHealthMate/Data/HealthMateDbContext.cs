using Microsoft.EntityFrameworkCore;

using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Data
{
    public class HealthMateDbContext : DbContext
    {
        public HealthMateDbContext(DbContextOptions<HealthMateDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<HealthRecord> HealthRecords {get;set;}
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Provider> Providers { get; set; }

    }
}