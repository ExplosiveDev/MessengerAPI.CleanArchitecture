using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class rename_field_in_MediaMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ea9dd96-b95a-4e3d-9257-c4a42fff280b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8eedf3c2-19e5-40b1-a181-50743046a76c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a9af2060-0d44-4cc1-a2a4-e6912acd3fa0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d79c22c7-205a-40a3-914f-7ed03bff7979"));

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Messages",
                newName: "Caption");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Caption",
                table: "Messages",
                newName: "Text");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("1ea9dd96-b95a-4e3d-9257-c4a42fff280b"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("8eedf3c2-19e5-40b1-a181-50743046a76c"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("a9af2060-0d44-4cc1-a2a4-e6912acd3fa0"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("d79c22c7-205a-40a3-914f-7ed03bff7979"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" }
                });
        }
    }
}
