using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShowRegSys.Models;

namespace ShowRegSys.DAL
{
    public class ShowContext : DbContext
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Pkr> Pkrs { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Class> Classes { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}