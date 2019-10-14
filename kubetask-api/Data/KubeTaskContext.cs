using kubetask_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubetask_api.Data
{
    public class KubeTaskContext: DbContext
    {
        public KubeTaskContext(DbContextOptions<KubeTaskContext> options) : base(options) { }

        public DbSet<KTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KTask>().Property(t => t.Id).HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<User>().Property(u => u.Id).HasValueGenerator<GuidValueGenerator>();

            modelBuilder.Entity<KTask>().ToContainer("Tasks");
            modelBuilder.Entity<User>().ToContainer("Users");
            base.OnModelCreating(modelBuilder);
        }
    }
}
