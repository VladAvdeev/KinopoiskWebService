using Kinopoisk.Db.Entities;
using Kinopoisk.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinopoisk.DAL.Configuration
{
    public class MovieModelConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("movies", "public");
            builder.Property(p => p.MovieId).HasColumnName("movie_id").HasDefaultValueSql();
            builder.Property(p => p.MovieName).HasColumnName("movie_name");
            builder.Property(p => p.CreateYear).HasColumnName("create_year");
            builder.Property(p => p.Country).HasColumnName("country");
            builder.HasKey(p => p.MovieId); ;
            builder.HasOne(p => p.Producer)
                .WithMany(t => t.Movies)
                .HasForeignKey(t => t.ProducerId);
        }
    }
}
