using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Types
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.UserName)
                .HasColumnName("name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(i => i.Password)
                .HasColumnName("password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(i => i.Email)
                .HasColumnName("email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}