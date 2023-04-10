using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VidlyNew.Models;

namespace Vidli.Models.Persistence.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(m => m.NumberInStock)
                .IsRequired();

            builder
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(g => g.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
