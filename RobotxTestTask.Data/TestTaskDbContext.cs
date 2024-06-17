using Microsoft.EntityFrameworkCore;
using RobotxTestTask.Common.Models;
using RobotxTestTask.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RobotxTestTask.Data
{
    public class TestTaskDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .Property(c => c.CardCode)
                .IsRequired();
        }
    }
}
