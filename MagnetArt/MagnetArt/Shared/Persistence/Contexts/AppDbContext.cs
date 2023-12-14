using MagnetArt.MagnetArtSystem.Domain.Models;
using MagnetArt.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MagnetArt.Shared.Persistence.Contexts
{
    public class AppDbContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Author>().ToTable("Authors");
            builder.Entity<Author>().HasKey(p => p.Id);
            builder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Author>().Property(p => p.FirstName).IsRequired();
            builder.Entity<Author>().Property(p => p.LastName).IsRequired();
            builder.Entity<Author>().Property(p => p.NickName).IsRequired().HasMaxLength(15);
            builder.Entity<Author>().Property(p => p.PhotoUrl);

            builder.Entity<Provider>().ToTable("Providers");
            builder.Entity<Provider>().HasKey(p => p.Id);
            builder.Entity<Provider>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Provider>().Property(p => p.Name).IsRequired();
            builder.Entity<Provider>().Property(p => p.KeyRequired).HasDefaultValue(false);
            builder.Entity<Provider>().Property(p => p.ApiUrl);
            builder.Entity<Provider>().Property(p => p.Apikey);

            builder.UseSnakeCaseNamingConvention();























        }

    }
}
