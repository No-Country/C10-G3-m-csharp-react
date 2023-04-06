using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inclusive.Migrations
{
    public partial class review_integrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a177bd99-7e6b-4c17-a341-9b537624cf27"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: new Guid("e396c8bf-b332-4fe2-b5d5-f21088845ce7"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A5051E62-875D-4169-B97B-5488F9EA54F2",
                column: "ConcurrencyStamp",
                value: "6a3ba878-9cb7-4ad3-a980-3ffcda23c5fd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A6EB18A6-5135-4951-8445-617BF404486A",
                column: "ConcurrencyStamp",
                value: "a719fdb0-6e71-4e09-b7cf-31518ea3e717");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29516888-6214-4FBB-A20B-7509B07F25CD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a311d34-7a45-43ed-a73a-cee4139f7940", "AQAAAAEAACcQAAAAEHag3+2BPIpcNrJd0tUhgiOfv6pqF8tqJPuQlqDfIxRE2AAvEQR7elRNnxLeFzWtaQ==", "d210ba42-8849-4504-ab9d-f1bdc9041e59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D6C8B4EF-4926-472C-84B7-6BF2300CE8A5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "453ed3a1-121f-4708-8071-f440ddf5b618", "AQAAAAEAACcQAAAAEN5Jq+nygu7/bZUrSMMw/VEbUO1G0nprqixuTGI9c4Xo3YQVjMDG67qcYTzcLJbIlA==", "5b3c1fdc-ec95-4c9b-b76b-d2c309a89756" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Image", "Name" },
                values: new object[] { new Guid("c75a3a65-3d52-4484-acec-b353361475c3"), "Restaurantes de comidas rápidas y fáciles", null, "Restaurantes" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "BirthDate", "Dni", "Gender", "MaritalStatus", "Name", "Nationality", "Pep", "PhoneCode", "PhoneNumber", "SurNames", "TramitNumber" },
                values: new object[] { new Guid("c4fe478f-904e-470e-959a-152ae9a9bfd1"), new DateTime(2023, 4, 5, 10, 6, 43, 313, DateTimeKind.Local).AddTicks(6134), "12345678A", 0, 1, "José", 2, "A", "123", "12345678A", "Pérez Lopez", "12345678A" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("c75a3a65-3d52-4484-acec-b353361475c3"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "OwnerId",
                keyValue: new Guid("c4fe478f-904e-470e-959a-152ae9a9bfd1"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A5051E62-875D-4169-B97B-5488F9EA54F2",
                column: "ConcurrencyStamp",
                value: "735fa6c8-1e28-4321-a15d-a003e2f2bbd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "A6EB18A6-5135-4951-8445-617BF404486A",
                column: "ConcurrencyStamp",
                value: "5b3e1211-afce-4d0d-af06-465697501a4f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29516888-6214-4FBB-A20B-7509B07F25CD",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4f1c905-2936-44b4-8220-6f59b25a60b5", "AQAAAAEAACcQAAAAEGjEToCXsWHOPoA3tHvQr950aURVVkl7f203E3HkyDeQusUjESGMfj46oNdpB/W5Pw==", "183972df-5b27-4d51-8fc0-339a49de1c26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D6C8B4EF-4926-472C-84B7-6BF2300CE8A5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ac831ce-31fa-4719-986d-0e29ae7ee1d0", "AQAAAAEAACcQAAAAEFIKnCO2H7GjWdJx48u/FnNOz4FBM/R7WDREThF41TNMjQNjfUlErK4qE5FbPS6AHA==", "33c85fb3-ee78-40b1-96d6-1bebd1e5c8df" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Image", "Name" },
                values: new object[] { new Guid("a177bd99-7e6b-4c17-a341-9b537624cf27"), "Restaurantes de comidas rápidas y fáciles", null, "Restaurantes" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "BirthDate", "Dni", "Gender", "MaritalStatus", "Name", "Nationality", "Pep", "PhoneCode", "PhoneNumber", "SurNames", "TramitNumber" },
                values: new object[] { new Guid("e396c8bf-b332-4fe2-b5d5-f21088845ce7"), new DateTime(2023, 4, 4, 12, 17, 34, 804, DateTimeKind.Local).AddTicks(2051), "12345678A", 0, 1, "José", 2, "A", "123", "12345678A", "Pérez Lopez", "12345678A" });
        }
    }
}
