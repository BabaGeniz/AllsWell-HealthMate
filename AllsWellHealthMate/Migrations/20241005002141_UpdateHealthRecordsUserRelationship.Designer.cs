﻿// <auto-generated />
using System;
using AllsWellHealthMate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AllsWellHealthMate.Migrations
{
    [DbContext(typeof(HealthMateDbContext))]
    [Migration("20241005002141_UpdateHealthRecordsUserRelationship")]
    partial class UpdateHealthRecordsUserRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllsWellHealthMate.Models.HealthRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfRecord")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MedicalHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prescriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ScheduledAppointments")
                        .HasColumnType("datetime2");

                    b.Property<string>("TreatmentPlan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("HealthRecords");
                });

            modelBuilder.Entity("AllsWellHealthMate.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AllsWellHealthMate.Models.HealthRecord", b =>
                {
                    b.HasOne("AllsWellHealthMate.Models.User", null)
                        .WithOne("HealthRecord")
                        .HasForeignKey("AllsWellHealthMate.Models.HealthRecord", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AllsWellHealthMate.Models.User", b =>
                {
                    b.Navigation("HealthRecord");
                });
#pragma warning restore 612, 618
        }
    }
}
