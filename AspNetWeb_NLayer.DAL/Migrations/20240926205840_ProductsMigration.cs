using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetWeb_NLayer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "productitems",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeEngeeniring = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    durationMonth = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productitems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productorders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    typeEngeeniring = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeStudy = table.Column<int>(type: "int", nullable: false),
                    sumPay = table.Column<float>(type: "real", nullable: false),
                    guid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productorders", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productitems_name",
                table: "productitems",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productorders_guid",
                table: "productorders",
                column: "guid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productitems");

            migrationBuilder.DropTable(
                name: "productorders");
        }
    }
}
