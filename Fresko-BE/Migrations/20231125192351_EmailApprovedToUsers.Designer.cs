﻿// <auto-generated />
using System;
using MSSQLApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fresko_BE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231125192351_EmailApprovedToUsers")]
    partial class EmailApprovedToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fresko_BE.Data.TableModels.AllComponents", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("id");

                    b.ToTable("all_components");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "article_text"
                        },
                        new
                        {
                            id = 2,
                            name = "file_picker"
                        },
                        new
                        {
                            id = 3,
                            name = "image_picker"
                        },
                        new
                        {
                            id = 4,
                            name = "link_picker"
                        });
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.ArticleText", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.ToTable("article_text");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.FilePicker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("absolute_path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.ToTable("file_picker");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.ImagePicker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("absolute_path")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.ToTable("image_picker");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.LinkPicker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name_overwrite")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.ToTable("link_picker");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.Page", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("creation_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("page_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("parent_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("pages");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("page_content", b =>
                {
                    b.Property<int>("page_id")
                        .HasColumnType("int");

                    b.Property<int>("content_id")
                        .HasColumnType("int");

                    b.HasKey("page_id", "content_id");

                    b.HasIndex("content_id");

                    b.ToTable("page_content");
                });

            modelBuilder.Entity("page_content", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.AllComponents", null)
                        .WithMany()
                        .HasForeignKey("content_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fresko_BE.Data.TableModels.Page", null)
                        .WithMany()
                        .HasForeignKey("page_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
