﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCADA_backend;

#nullable disable

namespace SCADA_backend.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230827200546_ThirdTPTMigration")]
    partial class ThirdTPTMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SCADA_backend.Model.Tag", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Address")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Tags", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("SCADA_backend.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SCADA_backend.Model.AnalogInput", b =>
                {
                    b.HasBaseType("SCADA_backend.Model.Tag");

                    b.Property<int>("Driver")
                        .HasColumnType("int");

                    b.Property<double>("HighLimit")
                        .HasColumnType("double");

                    b.Property<double>("LowLimit")
                        .HasColumnType("double");

                    b.Property<int>("ScanTime")
                        .HasColumnType("int");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isScanning")
                        .HasColumnType("tinyint(1)");

                    b.ToTable("AnalogInputs", (string)null);
                });

            modelBuilder.Entity("SCADA_backend.Model.AnalogOutput", b =>
                {
                    b.HasBaseType("SCADA_backend.Model.Tag");

                    b.Property<double>("HighLimit")
                        .HasColumnType("double");

                    b.Property<double>("InitialValue")
                        .HasColumnType("double");

                    b.Property<double>("LowLimit")
                        .HasColumnType("double");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Value")
                        .HasColumnType("double");

                    b.ToTable("AnalogOutputs", (string)null);
                });

            modelBuilder.Entity("SCADA_backend.Model.DigitalInput", b =>
                {
                    b.HasBaseType("SCADA_backend.Model.Tag");

                    b.Property<int>("Driver")
                        .HasColumnType("int");

                    b.Property<double>("ScanTime")
                        .HasColumnType("double");

                    b.Property<bool>("isScanning")
                        .HasColumnType("tinyint(1)");

                    b.ToTable("DigitalInputs", (string)null);
                });

            modelBuilder.Entity("SCADA_backend.Model.DigitalOutput", b =>
                {
                    b.HasBaseType("SCADA_backend.Model.Tag");

                    b.Property<bool>("InitialValue")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Value")
                        .HasColumnType("tinyint(1)");

                    b.ToTable("DigitalOutputs", (string)null);
                });

            modelBuilder.Entity("SCADA_backend.Model.AnalogInput", b =>
                {
                    b.HasOne("SCADA_backend.Model.Tag", null)
                        .WithOne()
                        .HasForeignKey("SCADA_backend.Model.AnalogInput", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCADA_backend.Model.AnalogOutput", b =>
                {
                    b.HasOne("SCADA_backend.Model.Tag", null)
                        .WithOne()
                        .HasForeignKey("SCADA_backend.Model.AnalogOutput", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCADA_backend.Model.DigitalInput", b =>
                {
                    b.HasOne("SCADA_backend.Model.Tag", null)
                        .WithOne()
                        .HasForeignKey("SCADA_backend.Model.DigitalInput", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SCADA_backend.Model.DigitalOutput", b =>
                {
                    b.HasOne("SCADA_backend.Model.Tag", null)
                        .WithOne()
                        .HasForeignKey("SCADA_backend.Model.DigitalOutput", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
