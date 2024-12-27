using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class AccessControlContext : DbContext
    {
        public DbSet<Pass> Passes { get; set; }
        public DbSet<AccessRequest> AccessRequests { get; set; }

        public AccessControlContext(DbContextOptions<AccessControlContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccessRequest>()
                .HasOne<Pass>()
                .WithMany()
                .HasForeignKey(ar => ar.PassId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
