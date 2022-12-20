using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraApi.Migrations
{
    /// <inheritdoc />
    public partial class Radio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Alarm1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Alarm2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Alarm3 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: false),
                    AlarmsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radio_Alarm_AlarmsId",
                        column: x => x.AlarmsId,
                        principalTable: "Alarm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radio_AlarmsId",
                table: "Radio",
                column: "AlarmsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Alarm");
        }
    }
}
