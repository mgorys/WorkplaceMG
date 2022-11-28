﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkplaceMG.Entities;

#nullable disable

namespace WorkplaceMG.Migrations
{
    [DbContext(typeof(WorkplaceDbContext))]
    partial class WorkplaceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WorkplaceMG.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("StockCount")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.EquipmentForWorkplace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEquipment")
                        .HasColumnType("int");

                    b.Property<int>("IdWorkplace")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEquipment");

                    b.HasIndex("IdWorkplace");

                    b.ToTable("EquipmentForWorkplaces");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdWorkplace")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdEmployee");

                    b.HasIndex("IdWorkplace");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.Workplace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<int>("Room")
                        .HasColumnType("int");

                    b.Property<int>("Table")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workplaces");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.EquipmentForWorkplace", b =>
                {
                    b.HasOne("WorkplaceMG.Entities.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("IdEquipment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkplaceMG.Entities.Workplace", "Workplace")
                        .WithMany()
                        .HasForeignKey("IdWorkplace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Workplace");
                });

            modelBuilder.Entity("WorkplaceMG.Entities.Reservation", b =>
                {
                    b.HasOne("WorkplaceMG.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkplaceMG.Entities.Workplace", "Workplace")
                        .WithMany()
                        .HasForeignKey("IdWorkplace")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Workplace");
                });
#pragma warning restore 612, 618
        }
    }
}
