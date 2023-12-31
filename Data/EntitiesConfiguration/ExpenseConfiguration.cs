namespace HouseFinances.Data.EntitiesConfiguration;

using HouseFinances.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.HasKey(e => e.ExpenseID);

        builder.Property(e => e.Amount)
               .HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.ExpenseType)
               .WithMany()
               .HasForeignKey(e => e.ExpenseTypeID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.RubricItem)
               .WithMany()
               .HasForeignKey(e => e.RubricItemID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Person)
               .WithMany()
               .HasForeignKey(e => e.PersonID)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.PaymentMethod)
               .WithMany()
               .HasForeignKey(e => e.PaymentMethodID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.Carrier)
               .WithMany()
               .HasForeignKey(e => e.CarrierID)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
