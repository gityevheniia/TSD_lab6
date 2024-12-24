using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
