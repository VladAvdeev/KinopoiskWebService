using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinopoisk.Db.Entities
{
    public class JenreToMovie
    {
        public int IdJenre { get; set; }
        public int IdMovie { get; set; }
        public Movie Movie { get; set; }
        public Jenre Jenre { get; set; }
    }
    public class JenreToMoviesConfiguration : IEntityTypeConfiguration<JenreToMovie>
    {
        public void Configure(EntityTypeBuilder<JenreToMovie> builder)
        {
            builder.ToTable("jenrestomovies", "public");
            builder.Property(p => p.IdJenre).HasColumnName("id_jenre");
            builder.Property(p => p.IdMovie).HasColumnName("id_movie");
            builder.HasKey(p => new { p.IdJenre, p.IdMovie });
            builder.HasOne(p => p.Jenre)
                .WithMany(p => p.JenreToMovies)
                .HasForeignKey(p => p.IdJenre);
            builder.HasOne(p => p.Movie)
                .WithMany(p => p.JenreToMovies)
                .HasForeignKey(p => p.IdMovie);
        }
    }
}
