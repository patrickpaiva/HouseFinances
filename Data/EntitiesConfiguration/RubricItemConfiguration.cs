namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class RubricItemConfiguration : IEntityTypeConfiguration<RubricItem>
{
    public void Configure(EntityTypeBuilder<RubricItem> builder)
    {
        builder.HasKey(ri => ri.RubricItemID);

        builder.HasOne(ri => ri.ExpenseType)
            .WithMany()
            .HasForeignKey(ri => ri.ExpenseTypeID)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
