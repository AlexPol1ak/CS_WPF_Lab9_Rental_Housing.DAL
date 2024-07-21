using CS_WPF_Lab9_Rental_Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_WPF_Lab9_Rental_Housing.DAL.Data.ModelConfigurations
{
    /// <summary>
    /// Configuration of the Apartment table.
    /// </summary>
    public class ApartmentConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartments");

            builder.Property(a=>a.Owner).IsRequired(false);
            builder.Property(a => a.Owner).HasMaxLength(45);

            builder.Property(a => a.OwnerTel).IsRequired(false);
            builder.Property(a => a.OwnerTel).HasColumnType("bigint");
        }
    }
}
