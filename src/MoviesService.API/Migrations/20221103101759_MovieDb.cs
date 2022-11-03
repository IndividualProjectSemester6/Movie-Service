using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesService.API.Migrations
{
    public partial class MovieDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A Dune movie", "Dune" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A Harry Potter movie", "Harry Potter & The Deathly Hallows Part 1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A Harry Potter movie", "Harry Potter & The Deathly Hallows Part 1" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "A Dune movie", "Dune" });
        }
    }
}
