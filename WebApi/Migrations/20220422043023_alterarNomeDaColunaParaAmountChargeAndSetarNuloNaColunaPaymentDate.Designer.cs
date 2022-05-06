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
    [Migration("20220422043023_alterarNomeDaColunaParaAmountChargeAndSetarNuloNaColunaPaymentDate")]
    partial class alterarNomeDaColunaParaAmountChargeAndSetarNuloNaColunaPaymentDate
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
                        .HasDefaultValue(new DateTime(2022, 4, 22, 4, 30, 22, 457, DateTimeKind.Utc).AddTicks(810))
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

            modelBuilder.Entity("WebApi.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Charges");
                });
#pragma warning restore 612, 618
        }
    }
}