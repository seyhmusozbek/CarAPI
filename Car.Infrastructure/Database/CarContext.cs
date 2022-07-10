using Car.Core.Entities;
using Car.Infrastructure.Configurations.FluentValidation;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Car.Infrastructure.Database
{
    public class CarContext : IdentityDbContext<AppUser>
    {
        public CarContext(DbContextOptions ops) : base(ops)
        {

        }

        public DbSet<CarDetails> CarDetails { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CarDetailsMap());
            builder.ApplyConfiguration(new AppUserMap());
        }

    }
}
