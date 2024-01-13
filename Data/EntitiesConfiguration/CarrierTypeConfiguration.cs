namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class CarrierTypeConfiguration : IEntityTypeConfiguration<CarrierType>
{
    public void Configure(EntityTypeBuilder<CarrierType> builder)
    {
        builder.HasKey(et => et.CarrierTypeID);

    }
}
