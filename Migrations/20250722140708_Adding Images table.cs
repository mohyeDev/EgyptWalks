using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgyptWalks.Migrations
{
    /// <inheritdoc />
    public partial class AddingImagestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtenstion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.InsertData(
                table: "Diffuclty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c50647c-8ced-4a45-bd5b-44fcb6f81acc"), "Hard" },
                    { new Guid("a7598d27-738b-4354-92c2-428f2868d5ca"), "Medium" },
                    { new Guid("e7de96c7-0fdb-478e-a114-c348a01fee7b"), "Easy" }
                });
        }
    }
}
