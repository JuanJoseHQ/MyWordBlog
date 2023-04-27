﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWordBlog.DAL;

#nullable disable

namespace MyWordBlog.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230427225127_Entity")]
    partial class Entity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.Comentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DatePublication")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Comentaries");
                });

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CantDisLikes")
                        .HasColumnType("int");

                    b.Property<int?>("CantLikes")
                        .HasColumnType("int");

                    b.Property<string>("Desctipton")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.UserLogin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UsersLogin");
                });

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.UserRegistred", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("Number")
                        .HasMaxLength(50)
                        .HasColumnType("bigint");

                    b.Property<int?>("Rol")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UsersRegistred");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserRegistred");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.UserAdmin", b =>
                {
                    b.HasBaseType("MyWordBlog.DAL.Entidades.UserRegistred");

                    b.Property<DateTime?>("Salary")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("UserAdmin");
                });

            modelBuilder.Entity("MyWordBlog.DAL.Entidades.UserCommon", b =>
                {
                    b.HasBaseType("MyWordBlog.DAL.Entidades.UserRegistred");

                    b.Property<DateTime?>("DateRegistred")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("UserCommon");
                });
#pragma warning restore 612, 618
        }
    }
}
