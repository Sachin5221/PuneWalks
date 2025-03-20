using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PuneWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5bdd875a-4391-41bd-b698-9a28eb69483d"), "Medium" },
                    { new Guid("8eb4ee42-2d96-4deb-94da-0a7334555205"), "Easy" },
                    { new Guid("eb94d7d8-be39-4d8f-b6f1-260bcdfa0bb3"), "Difficult" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("24723eba-058c-4582-a179-6b8a81da14f1"), "B1", "Pune Central", "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" },
                    { new Guid("430e0cd7-0d20-4890-91e0-f8af8e787b85"), "B2", "Pune North", "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" },
                    { new Guid("bd16b915-ae4a-4d6f-a008-eee0b90cf4f0"), "B3", "Pune South", "https://images.unsplash.com/photo-1504674900247-0877df9cc836?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5bdd875a-4391-41bd-b698-9a28eb69483d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8eb4ee42-2d96-4deb-94da-0a7334555205"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("eb94d7d8-be39-4d8f-b6f1-260bcdfa0bb3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("24723eba-058c-4582-a179-6b8a81da14f1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("430e0cd7-0d20-4890-91e0-f8af8e787b85"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bd16b915-ae4a-4d6f-a008-eee0b90cf4f0"));
        }
    }
}
