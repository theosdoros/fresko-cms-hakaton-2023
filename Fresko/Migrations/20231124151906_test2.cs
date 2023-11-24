using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Fresko.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "all_components",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "all_components",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "all_components",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "all_components",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
