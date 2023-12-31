namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder.HasKey(e => e.PaymentMethodID);

        builder.HasOne(pm => pm.Carrier)
            .WithMany(c => c.PaymentMethods)
            .HasForeignKey(pm => pm.CarrierId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
