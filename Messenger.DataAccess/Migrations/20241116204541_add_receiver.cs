using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class add_receiver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("011cbceb-1ba2-461f-9a7e-8a4bc1bce4e4"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("22ed321e-f1ba-433a-a6f9-e594e34f0676"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("2a663fbf-5eb6-4ec9-a6e2-306718fc6186"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("7a126025-ba52-4362-bf66-7f4f030cd77a"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("8914c049-26f5-4d29-9168-0c3998d6bf38"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("90e723a4-da51-458a-9cc6-7c3b6b3045ec"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("a009f598-82b5-449c-9a55-fe0d72467d13"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("c7f6f77c-5e90-4a93-a443-9efc893c89f9"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("c9f4c247-ab10-4a07-acde-3bb3d1f74c45"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("e25666e9-949c-45bd-92cc-af88d214eafc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("15d4249e-966f-46a4-9424-c339aa4b2642"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1eac84f8-be6b-400d-a654-9fb6c6fbe1c9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("40f98174-b001-4be8-99c4-a920854ff7f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("667f8602-7f3b-4934-a88a-302516913fdd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7b8023cc-d9b7-484d-b3c9-ac85d0004e09"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("be268e83-8ed1-46f6-bed5-2b56b54ab30d"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("03e1922e-d3d2-4f42-bfb0-8be990104fee"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("1290ac4a-7633-4e96-89ed-d6079236cfce"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("694d3d78-4a07-4588-bddb-294ad54bb2cf"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("a3d43ba3-64d7-40e1-8e3f-18be84fe5582"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("a63f6f43-b333-44b2-a801-eb787afc5cf1"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("d6e9a275-08b0-4e6d-b319-a1d4fb00a7c5"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("03e1922e-d3d2-4f42-bfb0-8be990104fee"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1290ac4a-7633-4e96-89ed-d6079236cfce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("694d3d78-4a07-4588-bddb-294ad54bb2cf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a3d43ba3-64d7-40e1-8e3f-18be84fe5582"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a63f6f43-b333-44b2-a801-eb787afc5cf1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d6e9a275-08b0-4e6d-b319-a1d4fb00a7c5"));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "ReceiverId", "SenderId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("011cbceb-1ba2-461f-9a7e-8a4bc1bce4e4"), "Sounds interesting, tell me more!", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4322) },
                    { new Guid("22ed321e-f1ba-433a-a6f9-e594e34f0676"), "Hello, how are you?", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4268) },
                    { new Guid("2a663fbf-5eb6-4ec9-a6e2-306718fc6186"), "Cool! What stack are you using?", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4326) },
                    { new Guid("7a126025-ba52-4362-bf66-7f4f030cd77a"), "It's a web app with a real-time chat feature.", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4324) },
                    { new Guid("8914c049-26f5-4d29-9168-0c3998d6bf38"), "Not much, just working on a project.", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4311) },
                    { new Guid("90e723a4-da51-458a-9cc6-7c3b6b3045ec"), "I'm using ASP.NET Core for the backend and React for the frontend.", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4328) },
                    { new Guid("a009f598-82b5-449c-9a55-fe0d72467d13"), "Thanks! I'll keep that in mind.", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4332) },
                    { new Guid("c7f6f77c-5e90-4a93-a443-9efc893c89f9"), "Nice choice! Let me know if you need help.", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4330) },
                    { new Guid("c9f4c247-ab10-4a07-acde-3bb3d1f74c45"), "What's new?", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4308) },
                    { new Guid("e25666e9-949c-45bd-92cc-af88d214eafc"), "I'm good, thanks!", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 11, 5, 15, 38, 36, 839, DateTimeKind.Utc).AddTicks(4279) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("15d4249e-966f-46a4-9424-c339aa4b2642"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("1eac84f8-be6b-400d-a654-9fb6c6fbe1c9"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("40f98174-b001-4be8-99c4-a920854ff7f5"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("667f8602-7f3b-4934-a88a-302516913fdd"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("7b8023cc-d9b7-484d-b3c9-ac85d0004e09"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("be268e83-8ed1-46f6-bed5-2b56b54ab30d"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" }
                });
        }
    }
}
