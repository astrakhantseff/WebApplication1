﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.DbContexts;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230620082124_child-table")]
    partial class childtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Cabinet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cabinet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = "123"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CabinetId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CabinetId = 1,
                            FullName = "full name",
                            RegionId = 0,
                            SpecialtyId = 0
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("WebApplication1.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("WebApplication1.Models.Patient", b =>
                {
                    b.HasOne("WebApplication1.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
