using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementAPI.Migrations
{
    public partial class AddRequestStatuesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aecbeea7-cb23-4dda-b887-e792053418d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb41ff4f-5630-4e7b-b81a-a617587d9b63");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "4b1b7798-798c-4648-b76d-b0b25e60a5c7");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "5573a213-f4e0-4626-a646-a64ff9dd0d0e");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "62eb6827-b6fe-4aa7-80b9-4b0c141cc593");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "708571f7-60e1-4b93-928a-77384dae0838");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "c0d852fb-71cc-4244-a973-7a8c5584cadb");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "c134b661-241c-4636-a4f3-f69d12c44541");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "e45c4493-9f19-4ae2-8aeb-8879b40ef25f");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "fb3b17b8-6eda-4e1b-b0d6-34c4679e5587");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "145bec24-ebbb-481c-9ed2-464319499abf", "82cbc747-34e3-4ad1-990e-212a75c18aee", "Customer", "CUSTOMER" },
                    { "b348ab92-28c1-42bc-89c4-feab143e4b33", "faf8981f-647b-476a-a099-db72b36389d9", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { "3a1c9ebb-2360-478a-afb4-e247ea2a2b95", 2, 200m, "203" },
                    { "3a9f9bd4-e893-4580-bd67-c3601ab52c64", 3, 400m, "302" },
                    { "813617a6-1374-4fd4-86b5-4883ae3973ed", 3, 400m, "301" },
                    { "a26b8bf9-f4bc-4b13-a55e-4b84380162c7", 3, 550m, "303" },
                    { "b02b93ad-8d8d-4d30-84cb-471dd4704e8c", 2, 150m, "102" },
                    { "c29f7baa-f597-48f3-a3cb-a73bc825318d", 2, 150m, "101" },
                    { "e13d2844-5d4c-4309-a00b-7aa01d076776", 2, 200m, "201" },
                    { "e64ffc2d-8389-4b58-b283-626a82642980", 2, 250m, "202" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "145bec24-ebbb-481c-9ed2-464319499abf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b348ab92-28c1-42bc-89c4-feab143e4b33");

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "3a1c9ebb-2360-478a-afb4-e247ea2a2b95");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "3a9f9bd4-e893-4580-bd67-c3601ab52c64");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "813617a6-1374-4fd4-86b5-4883ae3973ed");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "a26b8bf9-f4bc-4b13-a55e-4b84380162c7");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "b02b93ad-8d8d-4d30-84cb-471dd4704e8c");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "c29f7baa-f597-48f3-a3cb-a73bc825318d");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "e13d2844-5d4c-4309-a00b-7aa01d076776");

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: "e64ffc2d-8389-4b58-b283-626a82642980");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aecbeea7-cb23-4dda-b887-e792053418d9", "1fc963bd-62d9-4743-9544-b2166602df17", "Admin", "ADMIN" },
                    { "eb41ff4f-5630-4e7b-b81a-a617587d9b63", "46ce4825-e7cb-4232-afd7-670368b515c8", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Price", "RoomNumber" },
                values: new object[,]
                {
                    { "4b1b7798-798c-4648-b76d-b0b25e60a5c7", 3, 400m, "301" },
                    { "5573a213-f4e0-4626-a646-a64ff9dd0d0e", 2, 150m, "102" },
                    { "62eb6827-b6fe-4aa7-80b9-4b0c141cc593", 3, 550m, "303" },
                    { "708571f7-60e1-4b93-928a-77384dae0838", 3, 400m, "302" },
                    { "c0d852fb-71cc-4244-a973-7a8c5584cadb", 2, 250m, "202" },
                    { "c134b661-241c-4636-a4f3-f69d12c44541", 2, 150m, "101" },
                    { "e45c4493-9f19-4ae2-8aeb-8879b40ef25f", 2, 200m, "201" },
                    { "fb3b17b8-6eda-4e1b-b0d6-34c4679e5587", 2, 200m, "203" }
                });
        }
    }
}
