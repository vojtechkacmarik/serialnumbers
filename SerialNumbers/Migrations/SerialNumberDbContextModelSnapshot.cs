﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using SerialNumbers.EntityFramework;

namespace SerialNumbers.Migrations
{
    [DbContext(typeof(SerialNumberDbContext))]
    partial class SerialNumberDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sn")
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SerialNumbers.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SerialNumbers.Entity.Schema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Name", "CustomerId")
                        .IsUnique();

                    b.ToTable("Schemas");
                });

            modelBuilder.Entity("SerialNumbers.Entity.SchemaDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Increment");

                    b.Property<string>("Mask")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("SchemaId");

                    b.Property<int>("Seed");

                    b.HasKey("Id");

                    b.HasIndex("SchemaId");

                    b.ToTable("SchemaDefinitions");
                });

            modelBuilder.Entity("SerialNumbers.Entity.SchemaValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SubjectId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("SchemaValues");
                });

            modelBuilder.Entity("SerialNumbers.Entity.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SerialNumbers.Entity.Schema", b =>
                {
                    b.HasOne("SerialNumbers.Entity.Customer", "Customer")
                        .WithMany("Schemas")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SerialNumbers.Entity.SchemaDefinition", b =>
                {
                    b.HasOne("SerialNumbers.Entity.Schema", "Schema")
                        .WithMany("SchemaDefinitions")
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SerialNumbers.Entity.SchemaValue", b =>
                {
                    b.HasOne("SerialNumbers.Entity.Subject", "Subject")
                        .WithMany("SchemaValues")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
