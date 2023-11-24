using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fresko_BE.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "all_components",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_all_components", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article_text",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article_text", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "file_picker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    absolute_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_picker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "image_picker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    absolute_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_image_picker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "link_picker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    name_overwrite = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_link_picker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    page_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    creation_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "page_content",
                columns: table => new
                {
                    page_id = table.Column<int>(type: "int", nullable: false),
                    content_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_page_content", x => new { x.page_id, x.content_id });
                    table.ForeignKey(
                        name: "FK_page_content_all_components_content_id",
                        column: x => x.content_id,
                        principalTable: "all_components",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_page_content_pages_page_id",
                        column: x => x.page_id,
                        principalTable: "pages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "all_components",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "article_text" },
                    { 2, "file_picker" },
                    { 3, "image_picker" },
                    { 4, "link_picker" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_page_content_content_id",
                table: "page_content",
                column: "content_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
