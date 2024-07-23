using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Data.ModelConfigurations
{
    /// <summary>
    /// Configuration of the Houses table.
    /// </summary>
    public class HouseConfig : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("Houses");
            builder.Property(h => h.City).HasMaxLength(45);
            builder.Property(h => h.Street).HasMaxLength(45);
        }
    }
}
