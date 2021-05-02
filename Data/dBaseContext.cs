using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Alkemy_1.Models;

namespace Alkemy_1.Data
{
    public class dBaseContext : DbContext       
    {
        public dBaseContext(DbContextOptions<dBaseContext> options) : base(options)
        {
        }
        public DbSet<course> Courses { get; set; }
        public DbSet<professor> Professors { get; set; }
        public DbSet<student> Students { get; set; }
        public DbSet<inscription> Inscriptions { get; set; }

        public DbSet<Login> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>().ToTable("Course");
            modelBuilder.Entity<inscription>().ToTable("Inscription");
            modelBuilder.Entity<student>().ToTable("Student");
            modelBuilder.Entity<professor>().ToTable("Professor");
            modelBuilder.Entity<Login>().ToTable("Log");

        }




    }
}
