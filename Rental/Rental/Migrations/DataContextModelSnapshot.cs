﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rental.Data;

namespace Rental.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rental.Models.Booking", b =>
                {
                    b.Property<int>("A_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("A_FK_CARID")
                        .HasColumnType("int");

                    b.Property<int>("A_FK_USERID")
                        .HasColumnType("int");

                    b.Property<DateTime>("A_LEASE_END_DATE")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("A_LEASE_START_DATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("A_PRICE")
                        .HasColumnType("int");

                    b.Property<int>("A_TENURE")
                        .HasColumnType("int");

                    b.HasKey("A_ID");

                    b.HasIndex("A_FK_CARID");

                    b.HasIndex("A_FK_USERID");

                    b.ToTable("TBL_BOOKING");
                });

            modelBuilder.Entity("Rental.Models.Car", b =>
                {
                    b.Property<int>("A_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("A_COMPANY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("A_DISTANCE_DRIVEN")
                        .HasColumnType("int");

                    b.Property<string>("A_FUEL_TYPE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("A_IS_AVAILABLE")
                        .HasColumnType("bit");

                    b.Property<string>("A_MODEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("A_NUMBER_OF_SEATS")
                        .HasColumnType("int");

                    b.Property<int>("A_PRICE")
                        .HasColumnType("int");

                    b.Property<string>("A_TRANSMISSION")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("A_ID");

                    b.ToTable("TBL_CAR");
                });

            modelBuilder.Entity("Rental.Models.TBL_USER", b =>
                {
                    b.Property<int>("A_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("A_CITY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("A_EMAIL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("A_FIRST_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("A_LAST_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("A_PASSWORD_HASH")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("A_PASSWORD_SALT")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("A_ID");

                    b.ToTable("TBL_USER");
                });

            modelBuilder.Entity("Rental.Models.Booking", b =>
                {
                    b.HasOne("Rental.Models.Car", "Car")
                        .WithMany("A_BOOKING")
                        .HasForeignKey("A_FK_CARID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rental.Models.TBL_USER", "TBL_USER")
                        .WithMany("A_BOOKING")
                        .HasForeignKey("A_FK_USERID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
