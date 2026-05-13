using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateacc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1bf84af9-2961-4595-b680-06a10993cf02"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("86f252c1-9ed0-4e83-ad98-9a635a61d65f"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("8af35923-da53-4864-b54c-1660f81c7eef"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("93112bb6-d08f-448a-99fa-46d25c1520bc"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("3cd9993e-8690-4b6f-8ce9-d6e7f4341c49"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7a6e2513-9c90-4c96-82a2-45872f43314c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "JournalEntries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "AccountingRuleLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("15b3eccc-6f37-4414-a880-0f7c35c64b9b"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("360b9aa5-a5f1-4abd-b5f0-5e5c16ea5740"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("ecfad52b-cf36-48e1-baba-17ef0d6a28bb"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("ed13174b-6162-47dd-b05c-ef7818e5c743"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(5999));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 1, 24, 6, 248, DateTimeKind.Utc).AddTicks(6003));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("7975c866-5d28-4ed6-ab5a-1d03da34da65"), new Guid("7fffd1b6-c5d8-4700-bd68-599776213e6d"), null, new DateTime(2026, 3, 21, 4, 24, 6, 248, DateTimeKind.Local).AddTicks(5724), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("eff86cba-db1f-4881-ac8e-544764d63b27"), new Guid("e4579e3b-e537-405d-8c96-9df326580f7c"), null, new DateTime(2026, 3, 21, 4, 24, 6, 248, DateTimeKind.Local).AddTicks(5572), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("15b3eccc-6f37-4414-a880-0f7c35c64b9b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("360b9aa5-a5f1-4abd-b5f0-5e5c16ea5740"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ecfad52b-cf36-48e1-baba-17ef0d6a28bb"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ed13174b-6162-47dd-b05c-ef7818e5c743"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("7975c866-5d28-4ed6-ab5a-1d03da34da65"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("eff86cba-db1f-4881-ac8e-544764d63b27"));

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AccountingRuleLines");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "JournalEntries",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(1997));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("1bf84af9-2961-4595-b680-06a10993cf02"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("86f252c1-9ed0-4e83-ad98-9a635a61d65f"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("8af35923-da53-4864-b54c-1660f81c7eef"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("93112bb6-d08f-448a-99fa-46d25c1520bc"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(2489));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 19, 1, 45, 13, 855, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("3cd9993e-8690-4b6f-8ce9-d6e7f4341c49"), new Guid("976f245d-e894-4b0c-a731-cca016c5a097"), null, new DateTime(2026, 3, 19, 4, 45, 13, 855, DateTimeKind.Local).AddTicks(1419), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("7a6e2513-9c90-4c96-82a2-45872f43314c"), new Guid("265c7125-5693-4cb2-9066-138c86cce47f"), null, new DateTime(2026, 3, 19, 4, 45, 13, 855, DateTimeKind.Local).AddTicks(1642), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
