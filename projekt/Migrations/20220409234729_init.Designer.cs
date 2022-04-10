﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt.Models;

namespace projekt.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20220409234729_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Employee", b =>
                {
                    b.Property<int>("employeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("employeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            employeeID = 1,
                            firstName = "Ludwig",
                            lastName = "Oleby",
                            phone = "0736004656"
                        },
                        new
                        {
                            employeeID = 2,
                            firstName = "Anas",
                            lastName = "Qlok",
                            phone = "0701231231"
                        },
                        new
                        {
                            employeeID = 3,
                            firstName = "Tobias",
                            lastName = "Qlok",
                            phone = "0701231232"
                        },
                        new
                        {
                            employeeID = 4,
                            firstName = "Reidar",
                            lastName = "Qlok",
                            phone = "0701231233"
                        });
                });

            modelBuilder.Entity("Models.Projects", b =>
                {
                    b.Property<int>("projectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<string>("projectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("projectID");

                    b.HasIndex("employeeID");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            projectID = 1,
                            employeeID = 1,
                            projectName = "C#"
                        },
                        new
                        {
                            projectID = 2,
                            employeeID = 2,
                            projectName = "C#"
                        },
                        new
                        {
                            projectID = 3,
                            employeeID = 3,
                            projectName = "HTML"
                        },
                        new
                        {
                            projectID = 4,
                            employeeID = 4,
                            projectName = "CSS"
                        });
                });

            modelBuilder.Entity("Models.TimeReport", b =>
                {
                    b.Property<int>("reportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<int>("employeeID")
                        .HasColumnType("int");

                    b.Property<double>("reportedHours")
                        .HasColumnType("float");

                    b.HasKey("reportID");

                    b.HasIndex("employeeID");

                    b.ToTable("TimeReports");

                    b.HasData(
                        new
                        {
                            reportID = 1,
                            Week = 1,
                            date = 20220410,
                            employeeID = 1,
                            reportedHours = 37.5
                        },
                        new
                        {
                            reportID = 2,
                            Week = 1,
                            date = 20220410,
                            employeeID = 2,
                            reportedHours = 20.0
                        },
                        new
                        {
                            reportID = 3,
                            Week = 2,
                            date = 20220417,
                            employeeID = 3,
                            reportedHours = 40.0
                        },
                        new
                        {
                            reportID = 4,
                            Week = 2,
                            date = 20220417,
                            employeeID = 4,
                            reportedHours = 30.0
                        });
                });

            modelBuilder.Entity("Models.Projects", b =>
                {
                    b.HasOne("Models.Employee", "employee")
                        .WithMany("project")
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.TimeReport", b =>
                {
                    b.HasOne("Models.Employee", "Employee")
                        .WithMany("timeReports")
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}