using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeemailtophonewithchecking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "Email");
        }
    }
}
