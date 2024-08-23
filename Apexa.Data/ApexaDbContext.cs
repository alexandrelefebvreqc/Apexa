using Microsoft.EntityFrameworkCore;

namespace Apexa.Data
{
    public class ApexaDbContext : DbContext
    {
        public ApexaDbContext (DbContextOptions<ApexaDbContext> options):base(options) { }
        public virtual DbSet<Advisor> Advisors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Advisor>(entity => 
            { 
                entity.HasIndex(e => e.Sin, "NCIX_Advisors_Sin").IsUnique(); 
            }); 
        }
    }
}
