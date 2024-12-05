using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addreceiverIdintomessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("11345435-d057-43ad-b53e-77adc98576aa"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("1e4e73c2-a504-4712-90fa-d6e8e6d52ff8"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("2b22fbc4-6301-4db3-9949-14cdd5a38dbb"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("2ddf1249-8109-49a5-af72-3d821357cd9a"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("3721ad3c-133b-43fd-9e2b-920f350ec83e"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("3ef67504-47b1-4845-9f82-7b6a9fb4a9c8"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("5ba7dd78-8f92-4813-b769-4e659d6f2eb2"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("75fe4719-48b8-42ab-933d-b3f6bf579b9d"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("9b78db7c-edbe-4dbe-8dee-d8bb3ea5da6f"));

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: new Guid("d3902c3e-6bdf-4da9-9e6f-09b4a3218e61"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3657040b-cc63-47d7-a01f-9433854cb056"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8deba114-fef7-401b-8280-b46101234bd3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9d8f6531-0856-43d1-ae37-cb20ae9a6494"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f853e95-39fe-4628-a6c1-97244d1f218e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a629cd1a-7dc6-4416-980e-117f14b5785e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dc9fc5a8-bde2-4174-a38d-16c928a76628"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ReceiverId",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "SenderId", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("11345435-d057-43ad-b53e-77adc98576aa"), "I'm using ASP.NET Core for the backend and React for the frontend.", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8872) },
                    { new Guid("1e4e73c2-a504-4712-90fa-d6e8e6d52ff8"), "I'm good, thanks!", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8856) },
                    { new Guid("2b22fbc4-6301-4db3-9949-14cdd5a38dbb"), "Sounds interesting, tell me more!", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8864) },
                    { new Guid("2ddf1249-8109-49a5-af72-3d821357cd9a"), "Thanks! I'll keep that in mind.", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8880) },
                    { new Guid("3721ad3c-133b-43fd-9e2b-920f350ec83e"), "Nice choice! Let me know if you need help.", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8878) },
                    { new Guid("3ef67504-47b1-4845-9f82-7b6a9fb4a9c8"), "Hello, how are you?", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8844) },
                    { new Guid("5ba7dd78-8f92-4813-b769-4e659d6f2eb2"), "Cool! What stack are you using?", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8869) },
                    { new Guid("75fe4719-48b8-42ab-933d-b3f6bf579b9d"), "Not much, just working on a project.", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8861) },
                    { new Guid("9b78db7c-edbe-4dbe-8dee-d8bb3ea5da6f"), "What's new?", new Guid("6c0136a2-48d9-450f-9814-5cba270dce14"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8859) },
                    { new Guid("d3902c3e-6bdf-4da9-9e6f-09b4a3218e61"), "It's a web app with a real-time chat feature.", new Guid("57322de4-860d-4c50-950a-0e88f87d096c"), new DateTime(2024, 9, 11, 17, 35, 46, 937, DateTimeKind.Utc).AddTicks(8867) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("3657040b-cc63-47d7-a01f-9433854cb056"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("8deba114-fef7-401b-8280-b46101234bd3"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("9d8f6531-0856-43d1-ae37-cb20ae9a6494"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" },
                    { new Guid("9f853e95-39fe-4628-a6c1-97244d1f218e"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("a629cd1a-7dc6-4416-980e-117f14b5785e"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("dc9fc5a8-bde2-4174-a38d-16c928a76628"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" }
                });
        }
    }
}
