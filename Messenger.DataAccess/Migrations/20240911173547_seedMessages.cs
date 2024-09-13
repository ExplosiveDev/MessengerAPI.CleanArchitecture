using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Messenger.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0240bc5b-04f1-4fcd-8f07-9863110c3d84"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6900d124-517a-4b7f-98e9-9e32910bdee7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("92e8b77d-dc4c-43ce-9c22-4a89f5458db2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9608fbda-4b7b-4610-871c-7b95f9a0ced9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a248c062-819b-4a1f-87d7-be0d354f6862"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f251a53c-5a87-4e39-8d0b-577d4e0d9eb0"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Phone", "UserName" },
                values: new object[,]
                {
                    { new Guid("0240bc5b-04f1-4fcd-8f07-9863110c3d84"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380963333333", "Alice Johnson" },
                    { new Guid("6900d124-517a-4b7f-98e9-9e32910bdee7"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380964444444", "Bob Brown" },
                    { new Guid("92e8b77d-dc4c-43ce-9c22-4a89f5458db2"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380965555555", "Charlie Davis" },
                    { new Guid("9608fbda-4b7b-4610-871c-7b95f9a0ced9"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380962222222", "Jane Smith" },
                    { new Guid("a248c062-819b-4a1f-87d7-be0d354f6862"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380961111111", "John Doe" },
                    { new Guid("f251a53c-5a87-4e39-8d0b-577d4e0d9eb0"), "$2a$11$1m1GjCBPIuOWxIbPWYNMYu8NvAPFkxJLIhr0x26NzVnSA905TAk4a", "+380966666666", "David Evans" }
                });
        }
    }
}
