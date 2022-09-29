using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kinopoisk.Db.Entities
{
    public class Jenre
    {
        public int JenreId { get; set; }
        public string JenreName { get; set; }
       public ICollection<JenreToMovie> JenreToMovies { get; set; }

        public class JenreConfiguration : IEntityTypeConfiguration<Jenre>
        {
            public void Configure(EntityTypeBuilder<Jenre> builder)
            {
                builder.ToTable("jenres", "public");
                builder.Property(p => p.JenreId).HasColumnName("jenre_id");
                builder.Property(p => p.JenreName).HasColumnName("jenre_name");
                builder.HasKey(p => p.JenreId);

            }
        }
    }
}
