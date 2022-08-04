﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using People.Management.Infra.Context;

#nullable disable

namespace People.Management.Infra.Migrations
{
    [DbContext(typeof(MicroServiceContext))]
    [Migration("20220804141322_Fix-relationship")]
    partial class Fixrelationship
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("People.Management.Domain.Entites.Schooling", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchoolingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SchoolingId");

                    b.ToTable("Schooling", "u");
                });

            modelBuilder.Entity("People.Management.Domain.Entites.SchoolingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("ScholingType", "u");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25ea9187-4a1f-4b9f-b5a8-7aec8dc0f839"),
                            Name = "Infantil"
                        },
                        new
                        {
                            Id = new Guid("8a2d312d-e804-4f51-934a-fc5634c1940a"),
                            Name = "Fundamental"
                        },
                        new
                        {
                            Id = new Guid("0850abfa-209e-4c0e-b83f-34e62e492a89"),
                            Name = "Médio"
                        },
                        new
                        {
                            Id = new Guid("f67a3dac-3365-4994-abb8-5a9059c4e58f"),
                            Name = "Superior"
                        });
                });

            modelBuilder.Entity("People.Management.Domain.Entites.SchoolRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Format")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SchoolRecord", "u");
                });

            modelBuilder.Entity("People.Management.Domain.Entites.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("SchoolRecordId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SchoolingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SchoolRecordId");

                    b.HasIndex("SchoolingId");

                    b.ToTable("User", "u");
                });

            modelBuilder.Entity("People.Management.Domain.Entites.Schooling", b =>
                {
                    b.HasOne("People.Management.Domain.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("People.Management.Domain.Entites.SchoolingType", "Description")
                        .WithMany()
                        .HasForeignKey("SchoolingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Description");

                    b.Navigation("User");
                });

            modelBuilder.Entity("People.Management.Domain.Entites.SchoolRecord", b =>
                {
                    b.HasOne("People.Management.Domain.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("People.Management.Domain.Entites.User", b =>
                {
                    b.HasOne("People.Management.Domain.Entites.SchoolRecord", "SchoolRecord")
                        .WithMany()
                        .HasForeignKey("SchoolRecordId");

                    b.HasOne("People.Management.Domain.Entites.Schooling", "Schooling")
                        .WithMany()
                        .HasForeignKey("SchoolingId");

                    b.OwnsOne("People.Management.Domain.ValueObjects.AdressInformation", "AdressInformation", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Adress")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Adress");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Country");

                            b1.Property<int?>("Number")
                                .HasMaxLength(100)
                                .HasColumnType("int")
                                .HasColumnName("Number");

                            b1.Property<string>("Uf")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Uf");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("UserId");

                            b1.ToTable("User", "u");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("AdressInformation")
                        .IsRequired();

                    b.Navigation("SchoolRecord");

                    b.Navigation("Schooling");
                });
#pragma warning restore 612, 618
        }
    }
}
