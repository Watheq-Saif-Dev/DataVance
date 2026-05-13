using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpsateAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1d25f295-1b35-4d8c-8c94-f43dd6eb15a4"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("7a2a6bf7-6290-4b11-abe4-b8bf9dd499b6"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("acd09048-32d4-4bcd-8ac2-3ecf58d278e9"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d40f8f55-4478-45a3-9e60-fd683a65acd8"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5697));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5699));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("15d3a9ca-275e-4de6-af8a-6896cbe4bc02"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("3ca338d7-cdae-4952-9e71-88ab3f3519c2"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("728aa60f-a105-40a1-9d42-bc8fcaaba561"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("d9c054cc-06d9-43a3-9627-abfaba291e7c"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 17, 23, 46, 638, DateTimeKind.Utc).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("9a29feeb-35ad-46fd-a235-e70cd6da8c17"), new DateTime(2026, 3, 25, 20, 23, 46, 638, DateTimeKind.Local).AddTicks(5623) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("b884c9cf-0046-4d78-8533-364acbc80350"), new DateTime(2026, 3, 25, 20, 23, 46, 638, DateTimeKind.Local).AddTicks(5639) });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_Code",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("15d3a9ca-275e-4de6-af8a-6896cbe4bc02"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("3ca338d7-cdae-4952-9e71-88ab3f3519c2"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("728aa60f-a105-40a1-9d42-bc8fcaaba561"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d9c054cc-06d9-43a3-9627-abfaba291e7c"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4507));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId" },
                values: new object[,]
                {
                    { new Guid("1d25f295-1b35-4d8c-8c94-f43dd6eb15a4"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("7a2a6bf7-6290-4b11-abe4-b8bf9dd499b6"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") },
                    { new Guid("acd09048-32d4-4bcd-8ac2-3ecf58d278e9"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032") },
                    { new Guid("d40f8f55-4478-45a3-9e60-fd683a65acd8"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031") }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 25, 15, 50, 35, 151, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("01741cc1-5934-4b15-a5d8-0a91d23cf0ea"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("a6e66dcb-f076-4a15-b96d-f8c6125bdefa"), new DateTime(2026, 3, 25, 18, 50, 35, 151, DateTimeKind.Local).AddTicks(4232) });

            migrationBuilder.UpdateData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("be374aaf-2ebd-4517-b9ac-f3223e88d56a"),
                columns: new[] { "AccountId", "CreatedAt" },
                values: new object[] { new Guid("bfaa1482-2abf-43a2-a4c9-e70e42683b2d"), new DateTime(2026, 3, 25, 18, 50, 35, 151, DateTimeKind.Local).AddTicks(4254) });
        }
    }
}
