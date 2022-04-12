using CobrancaControle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CobrancaControle.Data.Types
{
    public class ChargeMap : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder.ToTable("charge");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.IssuanceDate).HasColumnName("issuance_date");
            builder.Property(i => i.IssuanceDate).IsRequired();

            builder.Property(i => i.DueDate).HasColumnName("due_date");
            builder.Property(i => i.DueDate).IsRequired();

            builder.Property(i => i.PaymentDate).HasColumnName("payment_date");

            builder.Property(i => i.PaymentStatus).HasColumnName("payment_status");
            builder.Property(i => i.PaymentStatus).IsRequired();

            builder.Property(i => i.ChargeAmount).HasColumnName("charge_amount");
            builder.Property(i => i.ChargeAmount).IsRequired();

            builder.Property(i => i.ClientId).HasColumnName("client_id");
            builder.Property(i => i.ClientId).IsRequired();
        }
    }
}