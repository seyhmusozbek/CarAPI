using Car.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Infrastructure.Configurations.FluentValidation
{
    public class CarDetailsMap : IEntityTypeConfiguration<CarDetails>
    {
        public void Configure(EntityTypeBuilder<CarDetails> builder)
        {
            builder.Property(c => c.Brand).HasMaxLength(100);
            builder.Property(c => c.Model).HasMaxLength(100);

            builder.HasData(
                new CarDetails
                {
                    Id = 1,
                    Model = "SLR Mchlaren",
                    Brand = "Mercedes",
                    Navigation=true
                }
                );
        }
    }
}
