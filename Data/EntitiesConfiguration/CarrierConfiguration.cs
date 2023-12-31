namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class CarrierConfiguration : IEntityTypeConfiguration<Carrier>
{
    public void Configure(EntityTypeBuilder<Carrier> builder)
    {
        builder.HasKey(e => e.CarrierID);

        builder.HasMany(c => c.PaymentMethods)
               .WithOne(pm => pm.Carrier)
               .HasForeignKey(pm => pm.CarrierId);
    }
}
