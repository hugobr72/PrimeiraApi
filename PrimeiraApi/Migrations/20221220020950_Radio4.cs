using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraApi.Migrations
{
    /// <inheritdoc />
    public partial class Radio4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Radio_Alarm_AlarmsId",
                table: "Radio");

            migrationBuilder.DropIndex(
                name: "IX_Radio_AlarmsId",
                table: "Radio");

            migrationBuilder.DropColumn(
                name: "AlarmsId",
                table: "Radio");

            migrationBuilder.AddColumn<int>(
                name: "ModelRadioManagerId",
                table: "Alarm",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alarm_ModelRadioManagerId",
                table: "Alarm",
                column: "ModelRadioManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alarm_Radio_ModelRadioManagerId",
                table: "Alarm",
                column: "ModelRadioManagerId",
                principalTable: "Radio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alarm_Radio_ModelRadioManagerId",
                table: "Alarm");

            migrationBuilder.DropIndex(
                name: "IX_Alarm_ModelRadioManagerId",
                table: "Alarm");

            migrationBuilder.DropColumn(
                name: "ModelRadioManagerId",
                table: "Alarm");

            migrationBuilder.AddColumn<int>(
                name: "AlarmsId",
                table: "Radio",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Radio_AlarmsId",
                table: "Radio",
                column: "AlarmsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Radio_Alarm_AlarmsId",
                table: "Radio",
                column: "AlarmsId",
                principalTable: "Alarm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
