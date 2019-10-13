using kubetask_api.Models;
using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<User>().ToContainer("Users");
            base.OnModelCreating(modelBuilder);
        }
    }
}
