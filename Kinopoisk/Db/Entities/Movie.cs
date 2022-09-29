using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Db.Entities
{
    [Table(name: "movies", Schema = "public")]
    public class Movie
    {
        [Column("movie_id")]
        public int MovieId { get; set; }
        
        [Column("movie_name")]
        public string MovieName { get; set; }
        
        [Column("create_year")]
        public int CreateYear { get; set; }
        
        [Column("country")]
        public string Country { get; set; }
        
        [Column("producer_id")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ICollection<JenreToMovie> JenreToMovies { get; set; }


        public class MovieConfiguration : IEntityTypeConfiguration<Movie>
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
}
