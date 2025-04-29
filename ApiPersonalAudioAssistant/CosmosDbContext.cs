using Microsoft.EntityFrameworkCore;

namespace ApiPersonalAudioAssistant
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options)
        {
        }

        public DbSet<SubUser> SubUsers { get; set; }
        public DbSet<Voice> Voices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubUser>().ToContainer("SubUser");
            modelBuilder.Entity<Voice>().ToContainer("Voice");
        }
    }
}
