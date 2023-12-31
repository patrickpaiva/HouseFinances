namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
{
    public void Configure(EntityTypeBuilder<ExpenseType> builder)
    {
        builder.HasKey(et => et.ExpenseTypeID);

    }
}
