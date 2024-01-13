using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinances.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarrierPersonRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_PersonID",
                table: "Carriers",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_Persons_PersonID",
                table: "Carriers",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_Persons_PersonID",
                table: "Carriers");

            migrationBuilder.DropIndex(
                name: "IX_Carriers_PersonID",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "Carriers");
        }
    }
}
