using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7ee00405-df78-4cf4-8cee-a25dc82cdc1b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a27bdbbb-28e7-4c10-a8b6-724eb9f055b8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c414731a-2ed2-4aae-a6fe-dfd82d4ad4b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c5f7b554-decb-4250-8514-9a6d22a54862"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f5376788-a2ba-4414-a8f6-21639bc2c91e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("feda2a2e-b3cf-4ca5-be08-8563a68613f0"));

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Discriminator", "User1Id", "User2Id" },
                values: new object[] { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                columns: new[] { "Phone", "UserName" },
                values: new object[] { "+380962222222", "Jane Smith" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e59487c-0d0a-4df9-ae13-7c591c874bdd"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("3fd16fd8-eaea-49d4-b1c3-fc8deed2e640"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("5782ceac-7408-4ec5-b2f7-5347a1e1a383"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("9252a58e-30e9-48dd-8c84-2a4b906cf738"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("f9a74d03-b637-4787-bdf2-930eff19c944"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963554053", "Saller" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Discriminator", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("f9a74d03-b637-4787-bdf2-930eff19c944") },
                    { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"));

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"));

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "Id",
                keyValue: new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e59487c-0d0a-4df9-ae13-7c591c874bdd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3fd16fd8-eaea-49d4-b1c3-fc8deed2e640"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5782ceac-7408-4ec5-b2f7-5347a1e1a383"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9252a58e-30e9-48dd-8c84-2a4b906cf738"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9a74d03-b637-4787-bdf2-930eff19c944"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                columns: new[] { "Phone", "UserName" },
                values: new object[] { "+380963554053", "Saller" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("7ee00405-df78-4cf4-8cee-a25dc82cdc1b"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("a27bdbbb-28e7-4c10-a8b6-724eb9f055b8"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("c414731a-2ed2-4aae-a6fe-dfd82d4ad4b0"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("c5f7b554-decb-4250-8514-9a6d22a54862"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("f5376788-a2ba-4414-a8f6-21639bc2c91e"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("feda2a2e-b3cf-4ca5-be08-8563a68613f0"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });
        }
    }
}
