using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_ChatEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatEntity_Users_AdminId",
                table: "ChatEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatEntity_Users_User1Id",
                table: "ChatEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatEntity_Users_User2Id",
                table: "ChatEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatEntity_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_ChatEntity_ChatId",
                table: "UserChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatEntity",
                table: "ChatEntity");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("26b4c264-4b3d-459f-bbb0-b664dc17ba60"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("61ad3af6-ae6b-4b6c-950f-e04d28acefcc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa8ada99-8500-4dda-8766-46ca5d1904c4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ac780626-5ecf-4b35-a923-faf2decab4b9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dbbda4b8-ced6-4196-8556-32b690772283"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e39d8d66-a7e8-4a2f-9224-d3d4df455ee6"));

            migrationBuilder.RenameTable(
                name: "ChatEntity",
                newName: "Chats");

            migrationBuilder.RenameIndex(
                name: "IX_ChatEntity_User2Id",
                table: "Chats",
                newName: "IX_Chats_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChatEntity_User1Id",
                table: "Chats",
                newName: "IX_Chats_User1Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChatEntity_AdminId",
                table: "Chats",
                newName: "IX_Chats_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_AdminId",
                table: "Chats",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_User1Id",
                table: "Chats",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Users_User2Id",
                table: "Chats",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_AdminId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_User1Id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Users_User2Id",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Chats_ChatId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChats_Chats_ChatId",
                table: "UserChats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

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

            migrationBuilder.RenameTable(
                name: "Chats",
                newName: "ChatEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_User2Id",
                table: "ChatEntity",
                newName: "IX_ChatEntity_User2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_User1Id",
                table: "ChatEntity",
                newName: "IX_ChatEntity_User1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_AdminId",
                table: "ChatEntity",
                newName: "IX_ChatEntity_AdminId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatEntity",
                table: "ChatEntity",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("26b4c264-4b3d-459f-bbb0-b664dc17ba60"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("61ad3af6-ae6b-4b6c-950f-e04d28acefcc"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("aa8ada99-8500-4dda-8766-46ca5d1904c4"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("ac780626-5ecf-4b35-a923-faf2decab4b9"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("dbbda4b8-ced6-4196-8556-32b690772283"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("e39d8d66-a7e8-4a2f-9224-d3d4df455ee6"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ChatEntity_Users_AdminId",
                table: "ChatEntity",
                column: "AdminId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatEntity_Users_User1Id",
                table: "ChatEntity",
                column: "User1Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatEntity_Users_User2Id",
                table: "ChatEntity",
                column: "User2Id",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatEntity_ChatId",
                table: "Messages",
                column: "ChatId",
                principalTable: "ChatEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChats_ChatEntity_ChatId",
                table: "UserChats",
                column: "ChatId",
                principalTable: "ChatEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
