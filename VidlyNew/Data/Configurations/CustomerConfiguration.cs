using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vidli.Models.Persistence.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder
                .Property(c => c.Birthdate)
                .IsRequired(false);
        }
    }
}
