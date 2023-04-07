using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vidli.Models;
using Vidli.Models.Persistence.EntityConfigurations;

namespace VidlyNew.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CustomerConfiguration().Configure(builder.Entity<Customer>());
            new MovieConfiguration().Configure(builder.Entity<Movie>());
            new GenreConfiguration().Configure(builder.Entity<Genre>());
        }
    }
}