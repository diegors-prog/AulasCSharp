using CobrancaControle.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CobrancaControle.Data.Types
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("client");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasColumnName("name");
            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.Phone).HasColumnName("phone");
            builder.Property(i => i.Phone).IsRequired();
        }
    }
}