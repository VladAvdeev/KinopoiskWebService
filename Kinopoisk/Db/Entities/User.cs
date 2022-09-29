using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Db.Entities
{
    //[Table(name:"users",Schema ="Public")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
    }
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "public");
            builder.Property(x => x.Id).HasColumnName("id").HasDefaultValueSql();
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Age).HasColumnName("age");
            builder.HasKey(x => x.Id);
        }
    }

}
