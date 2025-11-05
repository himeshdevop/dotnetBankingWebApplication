using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBWebEFAPI.Migrations
{
    public partial class InitialCreateFive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audits",
                columns: table => new
                {
                    auditId = table.Column<string>(type: "TEXT", nullable: false),
                    auditRecord = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.auditId);
                });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "auditId", "auditRecord" },
                values: new object[] { "A001", "Admin created account with ID 1" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "auditId", "auditRecord" },
                values: new object[] { "A002", "Admin created account with ID 2" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "auditId", "auditRecord" },
                values: new object[] { "A003", "Admin updated account with ID 3" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "auditId", "auditRecord" },
                values: new object[] { "A004", "Admin deleted account with ID 4" });

            migrationBuilder.InsertData(
                table: "Audits",
                columns: new[] { "auditId", "auditRecord" },
                values: new object[] { "A005", "Admin updated account with ID 5" });

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T001",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9807));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T002",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9825));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T003",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9826));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T004",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T005",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T006",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9831));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T007",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9832));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T008",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T009",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T010",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9835));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T011",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9836));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T012",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T013",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T014",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9838));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T015",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9839));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T016",
                column: "date",
                value: new DateTime(2024, 10, 11, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T017",
                column: "date",
                value: new DateTime(2024, 10, 10, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9841));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T018",
                column: "date",
                value: new DateTime(2024, 10, 9, 12, 12, 18, 197, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "picture",
                value: "gamer.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "picture",
                value: "man.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "picture",
                value: "woman.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "picture",
                value: "profile.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "picture",
                value: "programmer.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "picture",
                value: "cat.png");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 1000, "No.6, Street 6, Colombo", "admin1.t@gmail.com", "Admin1", "test1000", "0762345678", "cat.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 1001, "No.6, Street 6, Colombo", "admin2.t@gmail.com", "Admin2", "test1001", "0762345678", "gamer.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T001",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4921));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T002",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T003",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T004",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4944));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T005",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4945));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T006",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4947));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T007",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T008",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4952));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T009",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4953));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T010",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4955));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T011",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T012",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4957));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T013",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4958));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T014",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T015",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4959));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T016",
                column: "date",
                value: new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T017",
                column: "date",
                value: new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Transaction",
                keyColumn: "transactionId",
                keyValue: "T018",
                column: "date",
                value: new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "picture",
                value: "./gamer.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "picture",
                value: "./man.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "picture",
                value: "./woman.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "picture",
                value: "./profile.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "picture",
                value: "./programmer.png");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "picture",
                value: "./cat.png");
        }
    }
}
