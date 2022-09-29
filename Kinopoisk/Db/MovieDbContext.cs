using Kinopoisk.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Kinopoisk.Db.Entities.Jenre;
using static Kinopoisk.Db.Entities.Movie;
using static Kinopoisk.Db.Entities.Producer;

namespace Kinopoisk.Db
{
    public class MovieDbContext : DbContext
        //обращение и подключение к базе данных
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Jenre> Jenres { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            var s = GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(s);
            /*modelBuilder.ApplyConfiguration(new ProducerConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new JenreConfiguration());
            modelBuilder.ApplyConfiguration(new JenreToMoviesConfiguration());*/
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kinopoisk;Username=postgres;Password=12345");
        }
    }
}
