using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinances.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarrierPaymentMethodRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Carriers_CarrierId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_CarrierId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CarrierId",
                table: "PaymentMethods");

            migrationBuilder.CreateTable(
                name: "CarrierPaymentMethods",
                columns: table => new
                {
                    CarrierID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodsPaymentMethodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrierPaymentMethods", x => new { x.CarrierID, x.PaymentMethodsPaymentMethodID });
                    table.ForeignKey(
                        name: "FK_CarrierPaymentMethods_Carriers_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carriers",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrierPaymentMethods_PaymentMethods_PaymentMethodsPaymentMethodID",
                        column: x => x.PaymentMethodsPaymentMethodID,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrierPaymentMethods_PaymentMethodsPaymentMethodID",
                table: "CarrierPaymentMethods",
                column: "PaymentMethodsPaymentMethodID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrierPaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "CarrierId",
                table: "PaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CarrierId",
                table: "PaymentMethods",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Carriers_CarrierId",
                table: "PaymentMethods",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "CarrierID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
