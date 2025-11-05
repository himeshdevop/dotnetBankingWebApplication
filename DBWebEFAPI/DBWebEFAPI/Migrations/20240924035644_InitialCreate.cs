using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBWebEFAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    accountNO = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    balance = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.accountNO);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    transactionId = table.Column<string>(type: "TEXT", nullable: false),
                    accountNO = table.Column<int>(type: "INTEGER", nullable: false),
                    amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.transactionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    phone = table.Column<string>(type: "TEXT", nullable: false),
                    picture = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 1, "No.55, Street 5, Colombo", "1000.00", "himesh.h@gmail.com", "Himesh", "0711234567" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 2, "No.1, Street 1, Colombo", "1500.00", "rivin.r@gmail.com", "Rivin", "0712345678" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 3, "No.2, Street 2, Colombo", "2000.00", "dilhan.d@gmail.com", "Dilhan", "0713456789" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 4, "No.3, Street 3, Colombo", "2500.00", "anuk.a@gmail.com", "Anuk", "0714567890" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 5, "No.4, Street 4, Colombo", "3000.00", "yasith.y@gmail.com", "Yasith", "0715678901" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountNO", "address", "balance", "email", "name", "phone" },
                values: new object[] { 6, "No.6, Street 6, Colombo", "3500.00", "thinali.t@gmail.com", "Thinali", "0716789012" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T001", 1, 100.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4921), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T002", 1, 50.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4942), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T003", 1, 200.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4943), "Transfer" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T004", 2, 250.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4944), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T005", 2, 100.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4945), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T006", 2, 300.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4947), "Transfer" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T007", 3, 400.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4948), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T008", 3, 150.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4952), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T009", 3, 500.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4953), "Transfer" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T010", 4, 350.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4955), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T011", 4, 200.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4956), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T012", 4, 450.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4957), "Transfer" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T013", 5, 500.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4958), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T014", 5, 250.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4959), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T015", 5, 600.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4959), "Transfer" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T016", 6, 700.00m, new DateTime(2024, 9, 23, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4960), "Deposit" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T017", 6, 300.00m, new DateTime(2024, 9, 22, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4961), "Withdrawal" });

            migrationBuilder.InsertData(
                table: "Transaction",
                columns: new[] { "transactionId", "accountNO", "amount", "date", "description" },
                values: new object[] { "T018", 6, 800.00m, new DateTime(2024, 9, 21, 9, 26, 44, 648, DateTimeKind.Local).AddTicks(4963), "Transfer" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 1, "No.55, Street 5, Colombo", "hh@gmail.com", "Himesh", "test1", "0712345678", "./gamer.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 2, "No.1, Street 1, Colombo", "rivin.r@gmail.com", "Rivin", "test2", "0722345678", "./man.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 3, "No.2, Street 2, Colombo", "dilhan.d@gmail.com", "Dilhan", "test3", "0732345678", "./woman.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 4, "No.3, Street 3, Colombo", "anuk.a@gmail.com", "Anuk", "test4", "0742345678", "./profile.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 5, "No.4, Street 4, Colombo", "yasith.y@gmail.com", "Yasith", "test5", "0752345678", "./programmer.png" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "email", "name", "password", "phone", "picture" },
                values: new object[] { 6, "No.6, Street 6, Colombo", "thinali.t@gmail.com", "Thinali", "test6", "0762345678", "./cat.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
