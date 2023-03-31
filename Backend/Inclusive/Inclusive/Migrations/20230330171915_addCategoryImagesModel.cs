using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inclusive.Migrations
{
    public partial class addCategoryImagesModel : Migration
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

            migrationBuilder.CreateTable(
                name: "CategoryImages",
                columns: table => new
                {
                    CategoryImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryImages", x => x.CategoryImageId);
                    table.ForeignKey(
                        name: "FK_CategoryImages_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f66a035f-56df-4295-8f4b-fef59716d477", "d406adff-fd00-4c38-9b66-979c8f197e1d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc805b0d-5c6b-4a2b-bd1e-a4106f8f71f3", "f21a30f8-32f6-4514-b7d3-a900837d4121", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("fc8f8241-3b51-4216-a8ed-71ae40d4e73b"), "Restaurantes de comidas rápidas y fáciles", "Restaurantes" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryImages_CategoryId",
                table: "CategoryImages",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f66a035f-56df-4295-8f4b-fef59716d477");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc805b0d-5c6b-4a2b-bd1e-a4106f8f71f3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("fc8f8241-3b51-4216-a8ed-71ae40d4e73b"));

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
