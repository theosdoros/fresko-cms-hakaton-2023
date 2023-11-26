using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fresko_BE.Migrations
{
    /// <inheritdoc />
    public partial class initmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "page_content",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    page_id = table.Column<int>(type: "int", nullable: false),
                    component_id = table.Column<int>(type: "int", nullable: false),
                    component_alias = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_page_content", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    password_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    approved = table.Column<bool>(type: "bit", nullable: false),
                    is_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageModel_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    page_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                    table.ForeignKey(
                        name: "FK_pages_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "all_components",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PageModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_all_components", x => x.id);
                    table.ForeignKey(
                        name: "FK_all_components_PageModel_PageModelId",
                        column: x => x.PageModelId,
                        principalTable: "PageModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "article_text",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    cretion_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pageid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_text", x => x.id);
                    table.ForeignKey(
                        name: "FK_article_text_pages_pageid",
                        column: x => x.pageid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "file_picker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    absolute_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    cretion_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pageid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_picker", x => x.id);
                    table.ForeignKey(
                        name: "FK_file_picker_pages_pageid",
                        column: x => x.pageid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_picker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    absolute_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    cretion_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pageid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image_picker", x => x.id);
                    table.ForeignKey(
                        name: "FK_image_picker_pages_pageid",
                        column: x => x.pageid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "link_picker",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_overwrite = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    cretion_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pageid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link_picker", x => x.id);
                    table.ForeignKey(
                        name: "FK_link_picker_pages_pageid",
                        column: x => x.pageid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllComponentsPage",
                columns: table => new
                {
                    Componentsid = table.Column<int>(type: "int", nullable: false),
                    Pagesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllComponentsPage", x => new { x.Componentsid, x.Pagesid });
                    table.ForeignKey(
                        name: "FK_AllComponentsPage_all_components_Componentsid",
                        column: x => x.Componentsid,
                        principalTable: "all_components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllComponentsPage_pages_Pagesid",
                        column: x => x.Pagesid,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "all_components",
                columns: new[] { "id", "PageModelId", "name" },
                values: new object[,]
                {
                    { 1, null, "article_text" },
                    { 2, null, "file_picker" },
                    { 3, null, "image_picker" },
                    { 4, null, "link_picker" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "approved", "email", "is_admin", "password_hash", "password_salt", "username" },
                values: new object[] { 1, true, "admin@admin.com", true, new byte[] { 224, 105, 191, 115, 133, 193, 173, 101, 128, 191, 8, 204, 170, 123, 22, 36, 145, 110, 22, 36, 34, 60, 211, 101, 234, 251, 238, 127, 51, 115, 143, 203, 23, 71, 50, 93, 48, 227, 149, 35, 154, 114, 189, 122, 215, 49, 213, 9, 130, 227, 105, 93, 117, 50, 211, 111, 224, 5, 131, 215, 22, 127, 168, 233 }, new byte[] { 235, 12, 152, 197, 184, 141, 68, 170, 66, 105, 78, 124, 64, 54, 68, 165, 182, 187, 115, 68, 15, 21, 144, 115, 181, 167, 120, 102, 167, 70, 46, 115, 88, 31, 238, 104, 210, 171, 246, 187, 116, 190, 150, 58, 12, 152, 79, 77, 16, 218, 50, 126, 62, 206, 172, 152, 120, 162, 42, 18, 232, 71, 220, 96, 46, 102, 132, 147, 208, 94, 235, 75, 86, 57, 17, 183, 171, 135, 107, 28, 108, 133, 99, 151, 157, 99, 51, 104, 227, 158, 241, 164, 78, 12, 21, 62, 80, 57, 17, 14, 86, 6, 47, 99, 1, 61, 209, 19, 16, 106, 69, 186, 7, 234, 155, 105, 112, 72, 46, 35, 139, 162, 251, 56, 147, 73, 71, 254 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_all_components_PageModelId",
                table: "all_components",
                column: "PageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AllComponentsPage_Pagesid",
                table: "AllComponentsPage",
                column: "Pagesid");

            migrationBuilder.CreateIndex(
                name: "IX_article_text_pageid",
                table: "article_text",
                column: "pageid");

            migrationBuilder.CreateIndex(
                name: "IX_file_picker_pageid",
                table: "file_picker",
                column: "pageid");

            migrationBuilder.CreateIndex(
                name: "IX_image_picker_pageid",
                table: "image_picker",
                column: "pageid");

            migrationBuilder.CreateIndex(
                name: "IX_link_picker_pageid",
                table: "link_picker",
                column: "pageid");

            migrationBuilder.CreateIndex(
                name: "IX_PageModel_UserId",
                table: "PageModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_pages_userid",
                table: "pages",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllComponentsPage");

            migrationBuilder.DropTable(
                name: "article_text");

            migrationBuilder.DropTable(
                name: "file_picker");

            migrationBuilder.DropTable(
                name: "image_picker");

            migrationBuilder.DropTable(
                name: "link_picker");

            migrationBuilder.DropTable(
                name: "page_content");

            migrationBuilder.DropTable(
                name: "all_components");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "PageModel");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
