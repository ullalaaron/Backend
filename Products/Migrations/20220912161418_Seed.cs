using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageURL", "Name", "Price" },
                values: new object[] { new Guid("086ca54e-2085-4689-a664-5d5416fa230d"), "", "The Bombastic", 1049.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageURL", "Name", "Price" },
                values: new object[] { new Guid("89917829-b744-44ec-bfb5-929e1e9ef06a"), "", "The Bombster", 999.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImageURL", "Name", "Price" },
                values: new object[] { new Guid("b03036b8-3e6a-42a5-a12d-31997a72d182"), "", "The Gigastic", 1199.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("086ca54e-2085-4689-a664-5d5416fa230d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89917829-b744-44ec-bfb5-929e1e9ef06a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b03036b8-3e6a-42a5-a12d-31997a72d182"));
        }
    }
}
