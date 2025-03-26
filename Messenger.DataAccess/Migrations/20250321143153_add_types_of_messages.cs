using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_types_of_messages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Messages_MessageId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("46019776-56a3-44f5-86c4-6dab8f573339"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("47aa528c-f051-4994-837e-91efea9bb422"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("761c9ee7-fa59-4987-acc8-800758066829"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cf0218b0-2717-4734-b11e-0e9062c56494"));

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Files",
                newName: "MediaMessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_MessageId",
                table: "Files",
                newName: "IX_Files_MediaMessageId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Messages",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediaType",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("22d2b2ca-a5f6-476d-bdf7-e947219aacc5"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("2e0b7b95-41e7-482a-bf96-6ae4d6ef7004"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("48262e45-a4d3-4fe6-a75f-96891011b904"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("5b107b1b-4049-4c5d-91f7-06d7b7e037cf"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Messages_MediaMessageId",
                table: "Files",
                column: "MediaMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Messages_MediaMessageId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22d2b2ca-a5f6-476d-bdf7-e947219aacc5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e0b7b95-41e7-482a-bf96-6ae4d6ef7004"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("48262e45-a4d3-4fe6-a75f-96891011b904"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b107b1b-4049-4c5d-91f7-06d7b7e037cf"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MediaType",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "MediaMessageId",
                table: "Files",
                newName: "MessageId");

            migrationBuilder.RenameIndex(
                name: "IX_Files_MediaMessageId",
                table: "Files",
                newName: "IX_Files_MessageId");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("46019776-56a3-44f5-86c4-6dab8f573339"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("47aa528c-f051-4994-837e-91efea9bb422"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("761c9ee7-fa59-4987-acc8-800758066829"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("cf0218b0-2717-4734-b11e-0e9062c56494"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Messages_MessageId",
                table: "Files",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
