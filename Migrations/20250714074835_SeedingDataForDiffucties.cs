using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgyptWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDiffucties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Diffuclties_DiffucltyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diffuclties",
                table: "Diffuclties");

            migrationBuilder.RenameTable(
                name: "Diffuclties",
                newName: "Diffuclty");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diffuclty",
                table: "Diffuclty",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Diffuclty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c50647c-8ced-4a45-bd5b-44fcb6f81acc"), "Hard" },
                    { new Guid("a7598d27-738b-4354-92c2-428f2868d5ca"), "Medium" },
                    { new Guid("e7de96c7-0fdb-478e-a114-c348a01fee7b"), "Easy" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Diffuclty_DiffucltyId",
                table: "Walks",
                column: "DiffucltyId",
                principalTable: "Diffuclty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Walks_Diffuclty_DiffucltyId",
                table: "Walks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diffuclty",
                table: "Diffuclty");

            migrationBuilder.DeleteData(
                table: "Diffuclty",
                keyColumn: "Id",
                keyValue: new Guid("6c50647c-8ced-4a45-bd5b-44fcb6f81acc"));

            migrationBuilder.DeleteData(
                table: "Diffuclty",
                keyColumn: "Id",
                keyValue: new Guid("a7598d27-738b-4354-92c2-428f2868d5ca"));

            migrationBuilder.DeleteData(
                table: "Diffuclty",
                keyColumn: "Id",
                keyValue: new Guid("e7de96c7-0fdb-478e-a114-c348a01fee7b"));

            migrationBuilder.RenameTable(
                name: "Diffuclty",
                newName: "Diffuclties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diffuclties",
                table: "Diffuclties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Walks_Diffuclties_DiffucltyId",
                table: "Walks",
                column: "DiffucltyId",
                principalTable: "Diffuclties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
