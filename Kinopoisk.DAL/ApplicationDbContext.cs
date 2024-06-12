using Kinopoisk.Db.Entities;
using Kinopoisk.Library.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kinopoisk.Library.Entity.Jenre;
//using static Kinopoisk.Library.Entity.Movie;

namespace Kinopoisk.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        DbSet<TestClass> testClasses;
        //DbSet<Jenre> Jenres { get; set; }
        public DbSet<Library.Entity.Movie> Movies { get; set; }
        //public DbSet<Producer> Producers { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        }
    }
}
