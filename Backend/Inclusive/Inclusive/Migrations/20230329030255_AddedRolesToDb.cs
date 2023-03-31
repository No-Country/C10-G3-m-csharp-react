using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inclusive.Migrations
{
    public partial class AddedRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("d7b2c33d-7321-4b70-b9cf-f3c5e42c9999"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "431c14ea-945d-44b3-8748-a988c29c8904", "7fc4ac86-8da7-47a2-ba38-2d367cd95ee7", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a45853c-cd95-4592-83ef-a533662abad8", "7a66fbeb-bd1f-4a44-abd1-cb94eca100ce", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("6b3a469c-02b6-4cbe-9d22-5aaf81ec96d7"), "Restaurantes de comidas rápidas y fáciles", "Restaurantes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431c14ea-945d-44b3-8748-a988c29c8904");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a45853c-cd95-4592-83ef-a533662abad8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("6b3a469c-02b6-4cbe-9d22-5aaf81ec96d7"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("d7b2c33d-7321-4b70-b9cf-f3c5e42c9999"), "Restaurantes de comidas rápidas y fáciles", "Restaurantes" });
        }
    }
}
