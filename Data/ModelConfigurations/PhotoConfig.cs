using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Data.ModelConfigurations
{
    /// <summary>
    /// Configuration of the Photos table.
    /// </summary>
    public class PhotoConfig : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photos");
            builder.Property(p => p.PhotoName).HasMaxLength(45);
        }
    }
}
