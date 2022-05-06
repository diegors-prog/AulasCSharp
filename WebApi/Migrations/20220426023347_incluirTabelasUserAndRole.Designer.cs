﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data.Context;

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220426023347_incluirTabelasUserAndRole")]
    partial class incluirTabelasUserAndRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("WebApi.Domain.Entities.Charge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<double>("AmountCharge")
                        .HasColumnType("REAL")
                        .HasColumnName("amount_charge");

                    b.Property<long>("CustomerId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("due_date");

                    b.Property<DateTime>("IssuanceDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("SMALLDATETIME")
                        .HasDefaultValue(new DateTime(2022, 4, 26, 2, 33, 46, 640, DateTimeKind.Utc).AddTicks(1680))
                        .HasColumnName("issuance_date");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("payment_date");

                    b.Property<bool>("PaymentStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false)
                        .HasColumnName("payment_status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("charge");
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("description");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("slug");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("WebApi.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT")
                        .HasColumnName("bio");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("password_hash");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("slug");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Slug" }, "IX_user_slug")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.Property<long>("role_id")
                        .HasColumnType("INTEGER");

                    b.Property<long>("user_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("role_id", "user_id");

                    b.HasIndex("user_id");

                    b.ToTable("user_role");
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Charge", b =>
                {
                    b.HasOne("WebApi.Domain.Entities.Customer", "Customer")
                        .WithMany("Charges")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Charge_Customer")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("user_role", b =>
                {
                    b.HasOne("WebApi.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("role_id")
                        .HasConstraintName("FK_user_role_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("user_id")
                        .HasConstraintName("FK_user_role_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Charges");
                });
#pragma warning restore 612, 618
        }
    }
}
