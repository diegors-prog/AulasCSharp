﻿// <auto-generated />
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220618001304_incluirColunaEmailNaTabelaUser")]
    partial class incluirColunaEmailNaTabelaUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}