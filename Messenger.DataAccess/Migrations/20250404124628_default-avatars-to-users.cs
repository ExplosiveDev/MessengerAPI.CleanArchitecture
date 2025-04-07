using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class defaultavatarstousers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1208dd42-88d9-45bb-ad10-0218f846e6d7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("49e2c08e-5858-4a91-9db1-a79af4b7a1a0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("715467e5-b597-4efa-9c29-a96b721a8f5d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8c4dd1ae-89f9-41c2-988a-6154255045ac"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c"),
                column: "ActiveAvatarId",
                value: new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                column: "ActiveAvatarId",
                value: new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"),
                column: "ActiveAvatarId",
                value: new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9a74d03-b637-4787-bdf2-930eff19c944"),
                column: "ActiveAvatarId",
                value: new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActiveAvatarId", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("013bba47-53cc-43a1-a39b-08447f8e278d"), new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("07499e59-9604-41d9-8a88-c95e079424ea"), new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("9928f923-b6bb-422e-bad9-43c7f0d5f3ba"), new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("e814d398-0c5d-44d0-88d8-bd52ffb82bf4"), new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("013bba47-53cc-43a1-a39b-08447f8e278d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07499e59-9604-41d9-8a88-c95e079424ea"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9928f923-b6bb-422e-bad9-43c7f0d5f3ba"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e814d398-0c5d-44d0-88d8-bd52ffb82bf4"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c"),
                column: "ActiveAvatarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("57322de4-860d-4c50-950a-0e88f87d096c"),
                column: "ActiveAvatarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"),
                column: "ActiveAvatarId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9a74d03-b637-4787-bdf2-930eff19c944"),
                column: "ActiveAvatarId",
                value: null);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActiveAvatarId", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("1208dd42-88d9-45bb-ad10-0218f846e6d7"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("49e2c08e-5858-4a91-9db1-a79af4b7a1a0"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("715467e5-b597-4efa-9c29-a96b721a8f5d"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("8c4dd1ae-89f9-41c2-988a-6154255045ac"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });
        }
    }
}
