using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_seeder_UserChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "UserChats",
                columns: new[] { "ChatId", "UserId" },
                values: new object[,]
                {
                    { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c") },
                    { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c") },
                    { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") },
                    { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") },
                    { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") },
                    { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), new Guid("f9a74d03-b637-4787-bdf2-930eff19c944") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("09e6fa45-b641-40e7-a35b-ea83f9d02522"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("3d021081-200f-4164-8fd8-db52e9d5e10a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("40d0836c-5f95-4fb2-ba38-7b5ae8ef33d2"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("50ed1795-2ccb-4bfe-b5bc-8862b760e1aa"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c") });

            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c") });

            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") });

            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") });

            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") });

            migrationBuilder.DeleteData(
                table: "UserChats",
                keyColumns: new[] { "ChatId", "UserId" },
                keyValues: new object[] { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), new Guid("f9a74d03-b637-4787-bdf2-930eff19c944") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09e6fa45-b641-40e7-a35b-ea83f9d02522"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3d021081-200f-4164-8fd8-db52e9d5e10a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40d0836c-5f95-4fb2-ba38-7b5ae8ef33d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("50ed1795-2ccb-4bfe-b5bc-8862b760e1aa"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("3e59487c-0d0a-4df9-ae13-7c591c874bdd"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("3fd16fd8-eaea-49d4-b1c3-fc8deed2e640"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("5782ceac-7408-4ec5-b2f7-5347a1e1a383"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("9252a58e-30e9-48dd-8c84-2a4b906cf738"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" }
                });
        }
    }
}
