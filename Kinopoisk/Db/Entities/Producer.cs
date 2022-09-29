using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Db.Entities
{
    [Table(name: "producers", Schema ="public")]
    public class Producer
    {
        //[Column("Producer_id")]
        public int ProducerId { get; set; }

        //[Column("Lastname")]
        public string LastName { get; set; }
        
        //[Column("Firstname")]
        public string FirstName { get; set; }

        //[Column("Birthday")]
        public DateOnly BirthDay { get; set; }
        
        //[Column("Country")]
        public string Country { get; set; }
        public ICollection<Movie> Movies { get; set; }


        public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
        {
            public void Configure(EntityTypeBuilder<Producer> builder)
            {
                builder.ToTable("producers", "public");
                builder.Property(p => p.ProducerId).HasColumnName("producer_id");
                builder.Property(p => p.FirstName).HasColumnName("firstname");
                builder.Property(p => p.LastName).HasColumnName("lastname");
                builder.Property(p => p.BirthDay).HasColumnName("birthday");
                builder.Property(p => p.Country).HasColumnName("country");
                builder.HasKey(p => p.ProducerId);
            }
        }


    }
}
