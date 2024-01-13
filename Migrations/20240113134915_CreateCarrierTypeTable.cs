using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinances.Migrations
{
    /// <inheritdoc />
    public partial class CreateCarrierTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Carriers",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "CarrierTypeID",
                table: "Carriers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarrierTypes",
                columns: table => new
                {
                    CarrierTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierTypes", x => x.CarrierTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carriers_CarrierTypeID",
                table: "Carriers",
                column: "CarrierTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carriers_CarrierTypes_CarrierTypeID",
                table: "Carriers",
                column: "CarrierTypeID",
                principalTable: "CarrierTypes",
                principalColumn: "CarrierTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carriers_CarrierTypes_CarrierTypeID",
                table: "Carriers");

            migrationBuilder.DropTable(
                name: "CarrierTypes");

            migrationBuilder.DropIndex(
                name: "IX_Carriers_CarrierTypeID",
                table: "Carriers");

            migrationBuilder.DropColumn(
                name: "CarrierTypeID",
                table: "Carriers");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Carriers",
                newName: "Name");
        }
    }
}
