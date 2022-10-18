using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesService.API.Migrations
{
    public partial class SeedInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), "A Star Wars movie", "Star Wars VI: Return of the Jedi" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), "A Harry Potter movie", "Harry Potter & The Deathly Hallows Part 1" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), "A Dune movie", "Dune" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"));
        }
    }
}
