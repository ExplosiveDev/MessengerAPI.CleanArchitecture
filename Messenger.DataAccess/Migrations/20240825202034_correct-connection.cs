using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class correctconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00a20901-5696-4a4e-b534-306c66dae5f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7de191ba-d878-4cdf-b971-786ccc609ec1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("83a40c9f-2d67-4a4c-a232-eb451347ea07"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("94b20026-0454-4030-a41f-87ceb2e7eeef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bac10742-fd6c-44ee-bb20-b39ad2320454"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ce566f04-ba2a-4581-b4f8-b35679bcdce7"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Connections",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("0240bc5b-04f1-4fcd-8f07-9863110c3d84"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("6900d124-517a-4b7f-98e9-9e32910bdee7"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("92e8b77d-dc4c-43ce-9c22-4a89f5458db2"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("9608fbda-4b7b-4610-871c-7b95f9a0ced9"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("a248c062-819b-4a1f-87d7-be0d354f6862"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("f251a53c-5a87-4e39-8d0b-577d4e0d9eb0"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0240bc5b-04f1-4fcd-8f07-9863110c3d84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6900d124-517a-4b7f-98e9-9e32910bdee7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("92e8b77d-dc4c-43ce-9c22-4a89f5458db2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9608fbda-4b7b-4610-871c-7b95f9a0ced9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a248c062-819b-4a1f-87d7-be0d354f6862"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f251a53c-5a87-4e39-8d0b-577d4e0d9eb0"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Connections");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("00a20901-5696-4a4e-b534-306c66dae5f6"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("7de191ba-d878-4cdf-b971-786ccc609ec1"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("83a40c9f-2d67-4a4c-a232-eb451347ea07"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("94b20026-0454-4030-a41f-87ceb2e7eeef"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("bac10742-fd6c-44ee-bb20-b39ad2320454"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("ce566f04-ba2a-4581-b4f8-b35679bcdce7"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" }
                });
        }
    }
}
