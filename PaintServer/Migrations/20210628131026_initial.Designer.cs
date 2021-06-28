﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PaintServer.Migrations
{
    [DbContext(typeof(ContextDAL))]
    [Migration("20210628131026_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.PersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastVisitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("DAL.Models.PictureModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("personModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("personModelId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("DAL.Models.PictureModel", b =>
                {
                    b.HasOne("DAL.Models.PersonModel", "personModel")
                        .WithMany("pictureModel")
                        .HasForeignKey("personModelId");

                    b.Navigation("personModel");
                });

            modelBuilder.Entity("DAL.Models.PersonModel", b =>
                {
                    b.Navigation("pictureModel");
                });
#pragma warning restore 612, 618
        }
    }
}