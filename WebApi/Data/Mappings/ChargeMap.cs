using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Data.Mappings
{
    public class ChargeMap : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable("charge");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.IssuanceDate)
                .HasColumnName("issuance_date")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime())
                .IsRequired();

            builder.Property(i => i.DueDate)
                .HasColumnName("due_date")
                .HasColumnType("SMALLDATETIME")
                .IsRequired();

            builder.Property(i => i.PaymentDate)
                .HasColumnName("payment_date")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(null);

            builder.Property(i => i.PaymentStatus)
                .HasColumnName("payment_status")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(i => i.AmountCharge)
                .HasColumnName("amount_charge")
                .IsRequired();

            builder.Property(i => i.CustomerId)
                .HasColumnName("customer_id")
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Charges)
                .HasConstraintName("FK_Charge_Customer")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
