using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateForPurchase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("0754fa67-b3f1-483b-892f-ae4c90495d12"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("1316d48b-07cb-446b-82c8-46de25ad197b"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("58e6145d-61cf-45cd-a77e-1f71c2eb040f"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("689a8dc2-f7cd-4923-9a8b-196619ee44df"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("0a3db73d-3f94-4685-b834-801bcceff129"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("56f6370a-a09f-43da-a48d-b2b521f51461"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3167));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("42116442-9038-4951-b94d-07fe2b3ecd1d"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("96c6933b-6f0a-4791-9f67-5add100dd49e"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("ce7471fa-8268-459f-96ec-2a04a2135797"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("d0f56e8a-7e14-4cba-bf7b-219130a7e24a"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3305));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 21, 59, 17, 707, DateTimeKind.Utc).AddTicks(3311));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("1088b7c5-3ed1-45d8-aa2a-36764908e2f1"), new Guid("b0990d7c-c1a1-4586-b1db-a78b0eb6a817"), null, new DateTime(2026, 3, 19, 0, 59, 17, 707, DateTimeKind.Local).AddTicks(2990), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("5309135e-232d-40c6-97b2-5e24cda06886"), new Guid("5ba87c61-0c31-4314-af2c-0591aa55a7c0"), null, new DateTime(2026, 3, 19, 0, 59, 17, 707, DateTimeKind.Local).AddTicks(3020), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("42116442-9038-4951-b94d-07fe2b3ecd1d"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("96c6933b-6f0a-4791-9f67-5add100dd49e"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("ce7471fa-8268-459f-96ec-2a04a2135797"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("d0f56e8a-7e14-4cba-bf7b-219130a7e24a"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("1088b7c5-3ed1-45d8-aa2a-36764908e2f1"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("5309135e-232d-40c6-97b2-5e24cda06886"));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3529));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3536));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("0754fa67-b3f1-483b-892f-ae4c90495d12"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" },
                    { new Guid("1316d48b-07cb-446b-82c8-46de25ad197b"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("58e6145d-61cf-45cd-a77e-1f71c2eb040f"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("689a8dc2-f7cd-4923-9a8b-196619ee44df"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3751));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("0a3db73d-3f94-4685-b834-801bcceff129"), new Guid("efd9f3b6-7cd0-46e8-a8eb-7c37908feff5"), null, new DateTime(2026, 3, 18, 4, 51, 40, 550, DateTimeKind.Local).AddTicks(3276), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("56f6370a-a09f-43da-a48d-b2b521f51461"), new Guid("37666ec1-ca11-41f2-a938-423760da0641"), null, new DateTime(2026, 3, 18, 4, 51, 40, 550, DateTimeKind.Local).AddTicks(3318), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }
    }
}
