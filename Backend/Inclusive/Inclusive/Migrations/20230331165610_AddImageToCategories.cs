using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inclusive.Migrations
{
    public partial class AddImageToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "332070ca-83b7-4d85-a35a-871e76382d15", "53028da6-523e-4c1f-9a22-546c67ba3f88", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53ad8000-e70d-45da-91d2-28ccfa79fbc3", "28d89096-e595-41f9-8314-01791381f9cf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Image", "Name" },
                values: new object[] { new Guid("8273b2ce-4258-4ac8-868d-4872be838801"), "Restaurantes de comidas rápidas y fáciles", null, "Restaurantes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332070ca-83b7-4d85-a35a-871e76382d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53ad8000-e70d-45da-91d2-28ccfa79fbc3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("8273b2ce-4258-4ac8-868d-4872be838801"));

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");

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
    }
}
