using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Asp.NetCoreProjectWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Kiralama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kiralama",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ogrenciId = table.Column<int>(type: "int", nullable: false),
                    KitapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiralama", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiralama_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Kiralama_KitapId",
                table: "Kiralama",
                column: "KitapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kiralama");
        }
    }
}
