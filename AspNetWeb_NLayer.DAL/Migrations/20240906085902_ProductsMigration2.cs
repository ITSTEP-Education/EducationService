using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetWeb_NLayer.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductsMigration2 : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_productitems_name",
                table: "productitems",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productitems");
        }
    }
}
