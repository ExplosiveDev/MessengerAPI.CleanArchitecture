using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_field_url_to_fileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61e321dc-8c7b-4879-b8d1-13ff0b63fb71"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7b63019-bd79-48ba-bcc6-5b0b7f598f1a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d52592be-5038-4f2d-aaee-a625f4763fe3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e0b753a8-8026-46aa-ae0b-d31fb1563afa"));

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("37cba081-6706-48f7-bb18-502550981e3f"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("769fa878-2666-452b-8af6-a468284a88c8"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("962b0689-6e17-41b3-a8fc-af02eedaf284"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("b63954e7-77eb-4139-b704-f0aff43038b6"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37cba081-6706-48f7-bb18-502550981e3f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("769fa878-2666-452b-8af6-a468284a88c8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("962b0689-6e17-41b3-a8fc-af02eedaf284"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b63954e7-77eb-4139-b704-f0aff43038b6"));

            migrationBuilder.DropColumn(
                name: "URL",
                table: "Files");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("61e321dc-8c7b-4879-b8d1-13ff0b63fb71"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("a7b63019-bd79-48ba-bcc6-5b0b7f598f1a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("d52592be-5038-4f2d-aaee-a625f4763fe3"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("e0b753a8-8026-46aa-ae0b-d31fb1563afa"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });
        }
    }
}
