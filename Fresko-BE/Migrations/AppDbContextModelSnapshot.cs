﻿// <auto-generated />
using System;
using MSSQLApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fresko_BE.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("user_id")
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

                    b.HasData(
                        new
                        {
                            id = 1,
                            approved = true,
                            email = "admin@admin.com",
                            is_admin = true,
                            password_hash = new byte[] { 224, 105, 191, 115, 133, 193, 173, 101, 128, 191, 8, 204, 170, 123, 22, 36, 145, 110, 22, 36, 34, 60, 211, 101, 234, 251, 238, 127, 51, 115, 143, 203, 23, 71, 50, 93, 48, 227, 149, 35, 154, 114, 189, 122, 215, 49, 213, 9, 130, 227, 105, 93, 117, 50, 211, 111, 224, 5, 131, 215, 22, 127, 168, 233 },
                            password_salt = new byte[] { 235, 12, 152, 197, 184, 141, 68, 170, 66, 105, 78, 124, 64, 54, 68, 165, 182, 187, 115, 68, 15, 21, 144, 115, 181, 167, 120, 102, 167, 70, 46, 115, 88, 31, 238, 104, 210, 171, 246, 187, 116, 190, 150, 58, 12, 152, 79, 77, 16, 218, 50, 126, 62, 206, 172, 152, 120, 162, 42, 18, 232, 71, 220, 96, 46, 102, 132, 147, 208, 94, 235, 75, 86, 57, 17, 183, 171, 135, 107, 28, 108, 133, 99, 151, 157, 99, 51, 104, 227, 158, 241, 164, 78, 12, 21, 62, 80, 57, 17, 14, 86, 6, 47, 99, 1, 61, 209, 19, 16, 106, 69, 186, 7, 234, 155, 105, 112, 72, 46, 35, 139, 162, 251, 56, 147, 73, 71, 254 },
                            username = "admin"
                        });
                });

            modelBuilder.Entity("Fresko_BE.Models.PageModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                    b.HasOne("Fresko_BE.Data.TableModels.User", null)
                        .WithMany("pages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
