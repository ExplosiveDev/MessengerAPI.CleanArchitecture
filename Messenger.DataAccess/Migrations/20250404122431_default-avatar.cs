using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class defaultavatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("16700432-4d05-4aed-b9c9-81ea78e63929"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("36840b5f-ee4f-4141-8e4e-df08e1e2f14f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96991479-a1ed-41b2-b8a6-37ea5f4d9762"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("eeea758d-90a2-421a-a617-4725c49bb169"));

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "ContentType", "FileName", "FilePath", "FileSize", "MediaMessageId", "URL", "UserId" },
                values: new object[] { new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"), "image/png", "user.png", "wwwroot\\uploads\\user.png", 19456L, null, "http://192.168.0.100:5187/uploads/user.png", null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "Id",
                keyValue: new Guid("beaac0ce-6668-4be8-a3a2-80f47544200d"));

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActiveAvatarId", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("16700432-4d05-4aed-b9c9-81ea78e63929"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("36840b5f-ee4f-4141-8e4e-df08e1e2f14f"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("96991479-a1ed-41b2-b8a6-37ea5f4d9762"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("eeea758d-90a2-421a-a617-4725c49bb169"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });
        }
    }
}
