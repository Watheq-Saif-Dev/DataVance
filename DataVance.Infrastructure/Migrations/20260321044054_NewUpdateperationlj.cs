using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateperationlj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("5594bb26-3b80-410a-b7fd-9ed2c5ae7321"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("b4243543-6fcf-45f3-afa1-f63c66f96fb7"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("bc6adfdf-836a-432f-a282-e1810861ed74"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("cf487f2d-cf74-42e5-bfa1-adeee17c2717"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("80031c4f-388e-43d2-b24c-e465c9c9ca2b"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d1ee2fbf-52ef-459f-9da5-762a6bed62ba"));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 40, 50, 373, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 40, 50, 373, DateTimeKind.Local).AddTicks(1126));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 397, DateTimeKind.Utc).AddTicks(9863));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("773927bd-80c1-40a9-b644-60a15d35f470"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("afd7f925-36d5-4e98-ab48-a1ee682bdffd"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("c82e8da5-380e-49e6-a085-6c1fbe40d100"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("e78a19c4-f59d-48ac-a1aa-d91f130c1bde"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 398, DateTimeKind.Utc).AddTicks(4));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 40, 50, 398, DateTimeKind.Utc).AddTicks(8));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("d85b41d4-5c9b-40d7-8018-8538298bcd5d"), new Guid("242102ae-3597-4f69-96d0-2a69fe108ef5"), null, new DateTime(2026, 3, 21, 7, 40, 50, 397, DateTimeKind.Local).AddTicks(9676), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("d960faf2-9084-4f70-bdd4-ff365b1e10cf"), new Guid("2e66fb04-d304-46c4-9d02-72daecef3dc6"), null, new DateTime(2026, 3, 21, 7, 40, 50, 397, DateTimeKind.Local).AddTicks(9704), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("773927bd-80c1-40a9-b644-60a15d35f470"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("afd7f925-36d5-4e98-ab48-a1ee682bdffd"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("c82e8da5-380e-49e6-a085-6c1fbe40d100"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("e78a19c4-f59d-48ac-a1aa-d91f130c1bde"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d85b41d4-5c9b-40d7-8018-8538298bcd5d"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("d960faf2-9084-4f70-bdd4-ff365b1e10cf"));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 13, 35, 640, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 7, 13, 35, 640, DateTimeKind.Local).AddTicks(2698));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6008));

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6062));

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("5594bb26-3b80-410a-b7fd-9ed2c5ae7321"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("b4243543-6fcf-45f3-afa1-f63c66f96fb7"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("bc6adfdf-836a-432f-a282-e1810861ed74"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("cf487f2d-cf74-42e5-bfa1-adeee17c2717"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                column: "CreatedAt",
                value: new DateTime(2026, 3, 21, 4, 13, 35, 656, DateTimeKind.Utc).AddTicks(6344));

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("80031c4f-388e-43d2-b24c-e465c9c9ca2b"), new Guid("a6d7f699-12f3-4385-8059-5d697722e36a"), null, new DateTime(2026, 3, 21, 7, 13, 35, 656, DateTimeKind.Local).AddTicks(5698), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("d1ee2fbf-52ef-459f-9da5-762a6bed62ba"), new Guid("94a476d4-9373-4019-a398-35464736fcaa"), null, new DateTime(2026, 3, 21, 7, 13, 35, 656, DateTimeKind.Local).AddTicks(5670), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }
    }
}
