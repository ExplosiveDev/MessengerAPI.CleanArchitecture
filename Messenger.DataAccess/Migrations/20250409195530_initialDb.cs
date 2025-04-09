using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    stingConnection = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ActiveIconId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User1Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Chats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveAvatarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Files_ActiveAvatarId",
                        column: x => x.ActiveAvatarId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleEntityUserEntity",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntityUserEntity", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleEntityUserEntity_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChats",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChats", x => new { x.UserId, x.ChatId });
                    table.ForeignKey(
                        name: "FK_UserChats_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChats_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "ContentType", "FileName", "FilePath", "FileSize", "GroupChatId", "MediaMessageId", "URL", "UserId" },
                values: new object[,]
                {
                    { new Guid("813c1973-8109-44e8-b583-b4a26452ea6e"), "image/png", "groups.png", "wwwroot\\uploads\\groups.png", 19000L, null, null, "http://192.168.0.100:5187/uploads/groups.png", null },
                    { new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "image/png", "user.png", "wwwroot\\uploads\\user.png", 19456L, null, null, "http://192.168.0.100:5187/uploads/user.png", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Seller" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, new Guid("57322de4-860d-4c50-950a-0e88f87d096c") },
                    { 1, new Guid("6c0136a2-48d9-450f-9814-5cba270dce14") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActiveAvatarId", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("04b56cb5-c667-4063-a557-b26053f69e63"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("58f87ba8-627e-4898-b9cc-0a337739c8af"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964674274", "Vlad Gromovij" },
                    { new Guid("6faba7f0-6e1c-42ab-bdce-8cc853535422"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("aed6380d-6e7c-4051-a0a4-48a78f8af48b"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("f9a74d03-b637-4787-bdf2-930eff19c944"), new Guid("a7674d3f-d622-4656-9499-d46e0c7ea61a"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963554053", "Saller" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Discriminator", "User1Id", "User2Id" },
                values: new object[,]
                {
                    { new Guid("53d3f541-fa16-47f6-9e95-1e1cba92419e"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("f9a74d03-b637-4787-bdf2-930eff19c944") },
                    { new Guid("a2872c6e-2e30-4566-9ab4-1515be72b7c5"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c") },
                    { new Guid("e99beb51-6653-4079-aa32-0d896ea309ff"), "PrivateChatEntity", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("46028997-952e-4f9c-9282-4ebd7526ea9c") }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Chats_ActiveIconId",
                table: "Chats",
                column: "ActiveIconId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_AdminId",
                table: "Chats",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User1Id",
                table: "Chats",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_User2Id",
                table: "Chats",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Files_GroupChatId",
                table: "Files",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_MediaMessageId",
                table: "Files",
                column: "MediaMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleEntityUserEntity_UsersId",
                table: "RoleEntityUserEntity",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChats_ChatId",
                table: "UserChats",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActiveAvatarId",
                table: "Users",
                column: "ActiveAvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_Files_ActiveIconId",
                table: "Chats",
                column: "ActiveIconId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                name: "FK_Files_Messages_MediaMessageId",
                table: "Files",
                column: "MediaMessageId",
                principalTable: "Messages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_Files_ActiveIconId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_ActiveAvatarId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "RoleEntityUserEntity");

            migrationBuilder.DropTable(
                name: "UserChats");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
