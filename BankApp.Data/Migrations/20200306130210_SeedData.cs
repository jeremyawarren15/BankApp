using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "ModifiedDate" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 788, DateTimeKind.Unspecified).AddTicks(5350), new TimeSpan(0, 0, 0, 0, 0)), "Tom", "Cruise", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "ModifiedDate" },
                values: new object[] { 2, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 788, DateTimeKind.Unspecified).AddTicks(6612), new TimeSpan(0, 0, 0, 0, 0)), "Bob", "Ross", null });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountHolderId", "AccountType", "CreatedDate", "ModifiedDate", "PIN" },
                values: new object[] { 1, 1, 2, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(197), new TimeSpan(0, 0, 0, 0, 0)), null, "1234" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountHolderId", "AccountType", "CreatedDate", "ModifiedDate", "PIN" },
                values: new object[] { 2, 1, 0, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 0, 0, 0, 0)), null, "4321" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountHolderId", "AccountType", "CreatedDate", "ModifiedDate", "PIN" },
                values: new object[] { 3, 2, 2, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(1733), new TimeSpan(0, 0, 0, 0, 0)), null, "1234" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountHolderId", "AccountType", "CreatedDate", "ModifiedDate", "PIN" },
                values: new object[] { 4, 2, 0, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(1735), new TimeSpan(0, 0, 0, 0, 0)), null, "4321" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CounterpartyAccountId", "CreatedDate", "ModifiedDate", "TransactionType" },
                values: new object[] { 1, 1, 2000m, null, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(3371), new TimeSpan(0, 0, 0, 0, 0)), null, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CounterpartyAccountId", "CreatedDate", "ModifiedDate", "TransactionType" },
                values: new object[] { 2, 2, 2000m, null, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(4964), new TimeSpan(0, 0, 0, 0, 0)), null, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CounterpartyAccountId", "CreatedDate", "ModifiedDate", "TransactionType" },
                values: new object[] { 3, 3, 2000m, null, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(4999), new TimeSpan(0, 0, 0, 0, 0)), null, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "CounterpartyAccountId", "CreatedDate", "ModifiedDate", "TransactionType" },
                values: new object[] { 4, 4, 2000m, null, new DateTimeOffset(new DateTime(2020, 3, 6, 13, 2, 9, 790, DateTimeKind.Unspecified).AddTicks(5001), new TimeSpan(0, 0, 0, 0, 0)), null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
