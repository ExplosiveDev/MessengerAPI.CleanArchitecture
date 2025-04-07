using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_active_avatar_to_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07839ddc-7bed-499b-bd6a-81be5e769e4d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2eb748ad-e64a-47d7-a0ad-824e975ebf28"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c547ffff-0d8c-41c7-af53-69ee1ff8b3d2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dce520b8-5e59-4391-a72d-662c8f65108b"));

            migrationBuilder.AddColumn<Guid>(
                name: "ActiveAvatarId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

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
                    { new Guid("16700432-4d05-4aed-b9c9-81ea78e63929"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("36840b5f-ee4f-4141-8e4e-df08e1e2f14f"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("96991479-a1ed-41b2-b8a6-37ea5f4d9762"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("eeea758d-90a2-421a-a617-4725c49bb169"), null, "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ActiveAvatarId",
                table: "Users",
                column: "ActiveAvatarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Files_ActiveAvatarId",
                table: "Users",
                column: "ActiveAvatarId",
                principalTable: "Files",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Files_ActiveAvatarId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ActiveAvatarId",
                table: "Users");

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

            migrationBuilder.DropColumn(
                name: "ActiveAvatarId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("07839ddc-7bed-499b-bd6a-81be5e769e4d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("2eb748ad-e64a-47d7-a0ad-824e975ebf28"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("c547ffff-0d8c-41c7-af53-69ee1ff8b3d2"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("dce520b8-5e59-4391-a72d-662c8f65108b"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" }
                });
        }
    }
}
