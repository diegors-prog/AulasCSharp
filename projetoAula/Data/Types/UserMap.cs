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
                .HasColumnName("username")
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

            builder.Property(i => i.Image)
                .HasColumnName("image")
                .IsRequired(false);

            builder.Property(i => i.Slug)
                .HasColumnName("slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            // Índices
            builder
                .HasIndex(i => i.Slug, "IX_user_slug")
                .IsUnique();

            builder.Property(i => i.Bio)
                .HasColumnName("bio")
                .IsRequired(false);

            // Relacionamentos
            builder
                .HasMany(i => i.Roles)
                .WithMany(i => i.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "user_role",
                    role => role
                        .HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("role_id")
                        .HasConstraintName("FK_user_role_role_id")
                        .OnDelete(DeleteBehavior.Restrict),
                    user => user
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("FK_user_role_user_id")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}