using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingRegistry.Infrastructure.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Discount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassCars_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassCustomers_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlate = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PassId = table.Column<int>(nullable: true),
                    CarCustomer_PassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_PassCars_PassId",
                        column: x => x.PassId,
                        principalTable: "PassCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cars_PassCustomers_CarCustomer_PassId",
                        column: x => x.CarCustomer_PassId,
                        principalTable: "PassCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTimeOffset>(nullable: false),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parkings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Discount", "Name" },
                values: new object[,]
                {
                    { 1, 0, "First Customer" },
                    { 2, 2, "Second Customer" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Discount", "Type" },
                values: new object[,]
                {
                    { 1, 0, "Daily" },
                    { 2, 5, "Weekly" },
                    { 3, 10, "Monthly" }
                });

            migrationBuilder.InsertData(
                table: "PassCars",
                columns: new[] { "Id", "PaymentTypeId" },
                values: new object[,]
                {
                    { 10, 1 },
                    { 11, 2 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "PassCustomers",
                columns: new[] { "Id", "CustomerId", "PaymentTypeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Discriminator", "NumberPlate", "PassId" },
                values: new object[] { 8, "CarCar", "AAA-001", 10 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Discriminator", "NumberPlate", "CarCustomer_PassId" },
                values: new object[,]
                {
                    { 1, "CarCustomer", "OOO-001", 1 },
                    { 2, "CarCustomer", "OOO-002", 1 },
                    { 3, "CarCustomer", "OOO-003", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Discriminator", "NumberPlate", "PassId" },
                values: new object[,]
                {
                    { 9, "CarCar", "AAA-002", 11 },
                    { 10, "CarCar", "AAA-003", 12 }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Discriminator", "NumberPlate", "CarCustomer_PassId" },
                values: new object[,]
                {
                    { 4, "CarCustomer", "TTT-001", 2 },
                    { 5, "CarCustomer", "TTT-002", 2 },
                    { 6, "CarCustomer", "XXX-001", 3 },
                    { 7, "CarCustomer", "XXX-002", 3 }
                });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "CarId", "EndDate", "StartDate" },
                values: new object[] { 1, 1, null!, new DateTimeOffset(new DateTime(2020, 6, 8, 8, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "CarId", "EndDate", "StartDate" },
                values: new object[] { 2, 1, new DateTimeOffset(new DateTime(2020, 5, 8, 9, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 5, 8, 8, 45, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "CarId", "EndDate", "StartDate" },
                values: new object[] { 3, 2, new DateTimeOffset(new DateTime(2020, 1, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PassId",
                table: "Cars",
                column: "PassId",
                unique: true,
                filter: "[PassId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCustomer_PassId",
                table: "Cars",
                column: "CarCustomer_PassId");

            migrationBuilder.CreateIndex(
                name: "IX_Parkings_CarId",
                table: "Parkings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_PassCars_PaymentTypeId",
                table: "PassCars",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PassCustomers_CustomerId",
                table: "PassCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PassCustomers_PaymentTypeId",
                table: "PassCustomers",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "PassCars");

            migrationBuilder.DropTable(
                name: "PassCustomers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");
        }
    }
}
