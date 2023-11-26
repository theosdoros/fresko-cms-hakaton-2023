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
    [Migration("20231126123106_init-migration")]
    partial class initmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AllComponentsPage", b =>
                {
                    b.Property<int>("Componentsid")
                        .HasColumnType("int");

                    b.Property<int>("Pagesid")
                        .HasColumnType("int");

                    b.HasKey("Componentsid", "Pagesid");

                    b.HasIndex("Pagesid");

                    b.ToTable("AllComponentsPage");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.AllComponents", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("PageModelId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("id");

                    b.HasIndex("PageModelId");

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

                    b.Property<DateTime>("cretion_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("pageid")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("id");

                    b.HasIndex("pageid");

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

                    b.Property<DateTime>("cretion_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("pageid")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pageid");

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

                    b.Property<DateTime>("cretion_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("pageid")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pageid");

                    b.ToTable("image_picker");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.LinkPicker", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("cretion_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("name_overwrite")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("pageid")
                        .HasColumnType("int");

                    b.Property<int>("position")
                        .HasColumnType("int");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("id");

                    b.HasIndex("pageid");

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

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("pages");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.PageContent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("component_alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("component_id")
                        .HasColumnType("int");

                    b.Property<int>("page_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("page_content");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_admin")
                        .HasColumnType("bit");

                    b.Property<byte[]>("password_hash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("password_salt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Fresko_BE.Models.PageModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PageModel");
                });

            modelBuilder.Entity("AllComponentsPage", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.AllComponents", null)
                        .WithMany()
                        .HasForeignKey("Componentsid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fresko_BE.Data.TableModels.Page", null)
                        .WithMany()
                        .HasForeignKey("Pagesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.AllComponents", b =>
                {
                    b.HasOne("Fresko_BE.Models.PageModel", null)
                        .WithMany("Content")
                        .HasForeignKey("PageModelId");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.ArticleText", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.Page", "page")
                        .WithMany()
                        .HasForeignKey("pageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.FilePicker", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.Page", "page")
                        .WithMany()
                        .HasForeignKey("pageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.ImagePicker", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.Page", "page")
                        .WithMany()
                        .HasForeignKey("pageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.LinkPicker", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.Page", "page")
                        .WithMany()
                        .HasForeignKey("pageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.Page", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.User", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Fresko_BE.Models.PageModel", b =>
                {
                    b.HasOne("Fresko_BE.Data.TableModels.User", "User")
                        .WithMany("pages")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Fresko_BE.Data.TableModels.User", b =>
                {
                    b.Navigation("pages");
                });

            modelBuilder.Entity("Fresko_BE.Models.PageModel", b =>
                {
                    b.Navigation("Content");
                });
#pragma warning restore 612, 618
        }
    }
}