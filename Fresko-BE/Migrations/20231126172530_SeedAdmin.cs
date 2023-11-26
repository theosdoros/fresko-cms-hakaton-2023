using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresko_BE.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "approved", "email", "is_admin", "password_hash", "password_salt", "username" },
                values: new object[] { 1, true, "admin@admin.com", true, new byte[] { 103, 59, 56, 237, 89, 44, 139, 169, 54, 162, 86, 99, 145, 7, 58, 171, 240, 208, 148, 186, 192, 229, 6, 113, 104, 10, 31, 212, 60, 229, 131, 8, 136, 8, 152, 136, 188, 53, 79, 94, 221, 157, 228, 55, 225, 25, 60, 71, 191, 228, 118, 54, 78, 194, 110, 237, 249, 71, 195, 72, 3, 40, 3, 208 }, new byte[] { 195, 154, 129, 207, 19, 128, 255, 25, 252, 18, 170, 129, 191, 205, 226, 212, 252, 89, 8, 176, 212, 72, 247, 241, 240, 120, 222, 103, 239, 250, 244, 116, 238, 29, 195, 47, 160, 238, 112, 148, 153, 214, 24, 244, 53, 200, 154, 185, 110, 80, 172, 187, 143, 56, 24, 29, 109, 104, 148, 40, 87, 226, 88, 146, 138, 195, 155, 81, 48, 80, 105, 136, 76, 173, 212, 182, 154, 214, 126, 92, 113, 159, 78, 189, 119, 160, 217, 188, 197, 215, 204, 207, 111, 194, 109, 224, 255, 208, 170, 12, 19, 45, 92, 58, 21, 187, 65, 56, 59, 126, 89, 82, 154, 21, 230, 63, 135, 14, 146, 207, 44, 184, 149, 40, 223, 34, 246, 162 }, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
