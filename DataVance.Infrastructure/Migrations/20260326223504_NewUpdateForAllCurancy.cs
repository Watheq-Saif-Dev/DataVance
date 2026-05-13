using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateForAllCurancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAllowedCurrencies_Accounts_AccountId",
                table: "AccountAllowedCurrencies");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("08b5d485-ff48-46f0-afeb-d95d37402096"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("2159d348-f2c9-4b33-a206-fbd55a350271"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("7dce793b-bbe9-49fe-8ad5-6bcb6167ae7a"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("9a202bd8-ac76-4a8d-8cdb-73c0afddbc09"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AccountAllowedCurrencies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "OperationId",
                table: "AccountAllowedCurrencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8468));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("3fd58bfa-ba46-4787-970b-ffd2c8223a32"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("80448700-d62b-433c-931e-b3e631becee0"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("ca7cc6c6-d1b1-4a5c-8893-0baeeef53eea"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("e3f5a259-e191-414a-a5d5-f157e0ad7f02"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 26, 22, 34, 56, 67, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("7777b2ee-b679-401a-aeab-f7060875ed0d"), new DateTime(2026, 3, 27, 1, 34, 56, 67, DateTimeKind.Local).AddTicks(8358) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("ef7953b9-4396-4ac1-ad64-077f872d6faf"), new DateTime(2026, 3, 27, 1, 34, 56, 67, DateTimeKind.Local).AddTicks(8375) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAllowedCurrencies_Accounts_AccountId",
                table: "AccountAllowedCurrencies",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAllowedCurrencies_Accounts_AccountId",
                table: "AccountAllowedCurrencies");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3fd58bfa-ba46-4787-970b-ffd2c8223a32"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("80448700-d62b-433c-931e-b3e631becee0"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ca7cc6c6-d1b1-4a5c-8893-0baeeef53eea"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("e3f5a259-e191-414a-a5d5-f157e0ad7f02"));

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "AccountAllowedCurrencies");

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "AccountAllowedCurrencies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("08b5d485-ff48-46f0-afeb-d95d37402096"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("2159d348-f2c9-4b33-a206-fbd55a350271"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("7dce793b-bbe9-49fe-8ad5-6bcb6167ae7a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("9a202bd8-ac76-4a8d-8cdb-73c0afddbc09"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 22, 38, 15, 837, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("d8ae8a6a-6c9c-4285-969b-f542062b8236"), new DateTime(2026, 3, 26, 1, 38, 15, 837, DateTimeKind.Local).AddTicks(4189) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("7845a4a1-684d-4727-9232-05d10f004722"), new DateTime(2026, 3, 26, 1, 38, 15, 837, DateTimeKind.Local).AddTicks(4270) });

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAllowedCurrencies_Accounts_AccountId",
                table: "AccountAllowedCurrencies",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
