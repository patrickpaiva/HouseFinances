using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseFinances.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carriers",
                columns: table => new
                {
                    CarrierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carriers", x => x.CarrierID);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    ExpenseTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.ExpenseTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodID);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Carriers_CarrierId",
                        column: x => x.CarrierId,
                        principalTable: "Carriers",
                        principalColumn: "CarrierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RubricItems",
                columns: table => new
                {
                    RubricItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubricItems", x => x.RubricItemID);
                    table.ForeignKey(
                        name: "FK_RubricItems_ExpenseTypes_ExpenseTypeID",
                        column: x => x.ExpenseTypeID,
                        principalTable: "ExpenseTypes",
                        principalColumn: "ExpenseTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTypeID = table.Column<int>(type: "int", nullable: false),
                    RubricItemID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false),
                    CarrierID = table.Column<int>(type: "int", nullable: false),
                    Installments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_Expenses_Carriers_CarrierID",
                        column: x => x.CarrierID,
                        principalTable: "Carriers",
                        principalColumn: "CarrierID");
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseTypes_ExpenseTypeID",
                        column: x => x.ExpenseTypeID,
                        principalTable: "ExpenseTypes",
                        principalColumn: "ExpenseTypeID");
                    table.ForeignKey(
                        name: "FK_Expenses_PaymentMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodID");
                    table.ForeignKey(
                        name: "FK_Expenses_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_RubricItems_RubricItemID",
                        column: x => x.RubricItemID,
                        principalTable: "RubricItems",
                        principalColumn: "RubricItemID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CarrierID",
                table: "Expenses",
                column: "CarrierID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseTypeID",
                table: "Expenses",
                column: "ExpenseTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentMethodID",
                table: "Expenses",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PersonID",
                table: "Expenses",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_RubricItemID",
                table: "Expenses",
                column: "RubricItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CarrierId",
                table: "PaymentMethods",
                column: "CarrierId");

            migrationBuilder.CreateIndex(
                name: "IX_RubricItems_ExpenseTypeID",
                table: "RubricItems",
                column: "ExpenseTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "RubricItems");

            migrationBuilder.DropTable(
                name: "Carriers");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");
        }
    }
}
