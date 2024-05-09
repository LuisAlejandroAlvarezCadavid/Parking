﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parking.Infrastructure.DataContext;

#nullable disable

namespace Parking.Infrastructure.Migrations
{
    [DbContext(typeof(IntegracionDbContext))]
    partial class IntegracionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Parking")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parking.Domain.Entities.Logs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnterTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeaveTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Pay")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValuePay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Logs", "Parking");
                });

            modelBuilder.Entity("Parking.Domain.Entities.MotorCycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnterTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeaveTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pay")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValuePay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MotorCycle", "Parking");
                });

            modelBuilder.Entity("Parking.Domain.Entities.Vehicule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EnterTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LeaveTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pay")
                        .HasColumnType("bit");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ValuePay")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vehicule", "Parking");
                });

            modelBuilder.Entity("Parking.Domain.Entities.VehiculeMotorCycleValuesToPay", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Pay")
                        .HasColumnType("bit");

                    b.Property<double>("ValueTOPayForADay")
                        .HasColumnType("float");

                    b.Property<double>("ValueTOPayForHour")
                        .HasColumnType("float");

                    b.Property<string>("VehiculeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehiculeMotorCycleValuesToPay", "Parking");
                });
#pragma warning restore 612, 618
        }
    }
}
