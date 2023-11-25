using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fresko_BE.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdminColumnToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is_admin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_admin",
                table: "users");
        }
    }
}
