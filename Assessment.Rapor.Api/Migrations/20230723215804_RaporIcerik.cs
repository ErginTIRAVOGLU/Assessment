using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Rapor.Api.Migrations
{
    /// <inheritdoc />
    public partial class RaporIcerik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TalepTarihi",
                table: "Raporlar",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.CreateTable(
                name: "RaporIcerik",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    Konum = table.Column<string>(type: "text", nullable: false),
                    KisiSayisi = table.Column<int>(type: "integer", nullable: false),
                    TelefonSayisi = table.Column<int>(type: "integer", nullable: false),
                    RaporlarId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaporIcerik", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_RaporIcerik_Raporlar_RaporlarId",
                        column: x => x.RaporlarId,
                        principalTable: "Raporlar",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaporIcerik_RaporlarId",
                table: "RaporIcerik",
                column: "RaporlarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaporIcerik");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TalepTarihi",
                table: "Raporlar",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
