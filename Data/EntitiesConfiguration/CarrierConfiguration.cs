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

        builder.HasOne(e => e.CarrierType)
               .WithMany()
               .HasForeignKey(e => e.CarrierTypeID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Person)
               .WithMany()
               .HasForeignKey(e => e.PersonID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.PaymentMethods)
               .WithMany()
               .UsingEntity(j => j.ToTable("CarrierPaymentMethods"));
    }
}
