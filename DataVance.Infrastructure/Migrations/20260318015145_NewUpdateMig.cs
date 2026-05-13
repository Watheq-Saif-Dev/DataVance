using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AccountingRules_OperationId",
                table: "AccountingRules");

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("176bdaaf-c3a7-47b6-a637-29c75b33a7ae"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("197f589e-2ef1-4190-b898-9803e6583b7e"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("51ef46f9-40b5-4c83-a7f2-e269a6299c01"));

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumn: "Id",
                keyValue: new Guid("dea72494-1986-4210-9815-023d7092ec14"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("8fc6c991-2122-48c8-b437-6ad6341ac1f7"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("9c6ef414-5e4e-4650-b479-cab0ce19cbe0"));

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AccountMappings");

            migrationBuilder.DropColumn(
                name: "TaxCodeId",
                table: "AccountMappings");

            migrationBuilder.EnsureSchema(
                name: "Accounting");

            migrationBuilder.RenameTable(
                name: "AccountMappings",
                newName: "AccountMappings",
                newSchema: "Accounting");

            migrationBuilder.RenameColumn(
                name: "WarehouseId",
                schema: "Accounting",
                table: "AccountMappings",
                newName: "TaxId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Vendors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Vendors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UnitCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UnitCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "UnitCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseReceipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchaseReceipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PurchaseReceipts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseReceipt_BranchId",
                table: "PurchaseReceipts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTax",
                table: "PurchaseReceipts",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "PurchaseReceiptLines",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PurchaseReceiptLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PurchaseReceiptLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "PurchaseReceiptLines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxAmount",
                table: "PurchaseReceiptLines",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxCodeId",
                table: "PurchaseReceiptLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OpeningBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OpeningBalances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "OpeningBalances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "JournalEntries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "JournalEntries",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ItemGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ItemGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ItemGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "InventoryBalances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "InventoryBalances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "InventoryBalances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "InventoryBalances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "FiscalYears",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FiscalYears",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "FiscalYears",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Currencies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Currencies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Branches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Branches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "AccountingRules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AccountingRules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AccountingRules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AccountingRules",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AccountingRules",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AccountingRuleLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AccountingRuleLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AccountingRuleLines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "AccountingRuleLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                schema: "Accounting",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountSourceType",
                schema: "Accounting",
                table: "AccountMappings",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "Accounting",
                table: "AccountMappings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "Accounting",
                table: "AccountMappings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                schema: "Accounting",
                table: "AccountMappings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                schema: "Accounting",
                table: "AccountMappings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ReferenceId",
                schema: "Accounting",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "LinkTax",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PurchaseReceiptId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTax", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkTax_PurchaseReceipts_PurchaseReceiptId",
                        column: x => x.PurchaseReceiptId,
                        principalTable: "PurchaseReceipts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccountingOperations",
                columns: new[] { "Id", "Code", "IsSystem", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"), "PUR_REC", true, "توريد مشتريات" },
                    { new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"), "STK_OUT", true, "صرف مخزني" }
                });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c1c1c1c1-d1d1-4123-8123-000000000021"),
                columns: new[] { "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3529), null, null });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c2c2c2c2-d2d2-4123-8123-000000000022"),
                columns: new[] { "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3532), null, null });

            migrationBuilder.UpdateData(
                table: "ItemGroups",
                keyColumn: "Id",
                keyValue: new Guid("c5c5c5c5-d5d5-4123-8123-000000000025"),
                columns: new[] { "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3536), null, null });

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
                columns: new[] { "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3745), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"),
                columns: new[] { "CreatedAt", "CreatedBy", "LastModified" },
                values: new object[] { new DateTime(2026, 3, 18, 1, 51, 40, 550, DateTimeKind.Utc).AddTicks(3751), null, null });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "CreatedAt", "CreatedBy", "Email", "IsActive", "LastModified", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("0a3db73d-3f94-4685-b834-801bcceff129"), new Guid("efd9f3b6-7cd0-46e8-a8eb-7c37908feff5"), null, new DateTime(2026, 3, 18, 4, 51, 40, 550, DateTimeKind.Local).AddTicks(3276), null, null, true, null, "مورد تجريبي 1", null, null, "VND-001" },
                    { new Guid("56f6370a-a09f-43da-a48d-b2b521f51461"), new Guid("37666ec1-ca11-41f2-a938-423760da0641"), null, new DateTime(2026, 3, 18, 4, 51, 40, 550, DateTimeKind.Local).AddTicks(3318), null, null, true, null, "شركة النور للتوريدات", null, null, "VND-002" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rule_Operation_Branch",
                table: "AccountingRules",
                columns: new[] { "OperationId", "BranchId" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRuleLines_StaticAccountId",
                table: "AccountingRuleLines",
                column: "StaticAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountMappings_AccountId",
                schema: "Accounting",
                table: "AccountMappings",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings",
                columns: new[] { "ReferenceId", "AccountSourceType", "Purpose", "BranchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinkTax_PurchaseReceiptId",
                table: "LinkTax",
                column: "PurchaseReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRuleLines_Accounts_StaticAccountId",
                table: "AccountingRuleLines",
                column: "StaticAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountMappings_Accounts_AccountId",
                schema: "Accounting",
                table: "AccountMappings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRuleLines_Accounts_StaticAccountId",
                table: "AccountingRuleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountMappings_Accounts_AccountId",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropTable(
                name: "LinkTax");

            migrationBuilder.DropIndex(
                name: "IX_Rule_Operation_Branch",
                table: "AccountingRules");

            migrationBuilder.DropIndex(
                name: "IX_AccountingRuleLines_StaticAccountId",
                table: "AccountingRuleLines");

            migrationBuilder.DropIndex(
                name: "IX_AccountMappings_AccountId",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropIndex(
                name: "IX_Unique_Mapping_Per_Branch",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DeleteData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.DeleteData(
                table: "AccountingOperations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4b5c-9d8e-1f2a3b4c5d6e"));

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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UnitCategories");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UnitCategories");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "UnitCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "PurchaseReceipt_BranchId",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "TotalTax",
                table: "PurchaseReceipts");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "TaxAmount",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "TaxCodeId",
                table: "PurchaseReceiptLines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OpeningBalances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OpeningBalances");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "OpeningBalances");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "JournalEntries");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ItemGroups");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "InventoryBalances");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "InventoryBalances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "InventoryBalances");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "InventoryBalances");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "FiscalYears");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AccountingRules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AccountingRules");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountingRules");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AccountingRules");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AccountingRules");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropColumn(
                name: "LastModified",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropColumn(
                name: "Purpose",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                schema: "Accounting",
                table: "AccountMappings");

            migrationBuilder.RenameTable(
                name: "AccountMappings",
                schema: "Accounting",
                newName: "AccountMappings");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "AccountMappings",
                newName: "WarehouseId");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "AccountSourceType",
                table: "AccountMappings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaxCodeId",
                table: "AccountMappings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "Id", "Barcode", "ConversionFactor", "GlobalUnitId", "IsBaseUnit", "IsPurchaseUnit", "IsSalesUnit", "ItemId", "UnitName" },
                values: new object[,]
                {
                    { new Guid("176bdaaf-c3a7-47b6-a637-29c75b33a7ae"), "725110002", 1000m, new Guid("b4b4c4d4-e4f4-4123-8123-000000000014"), false, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "كيلو" },
                    { new Guid("197f589e-2ef1-4190-b898-9803e6583b7e"), "725110001", 1m, new Guid("b3b3c3d3-e3f3-4123-8123-000000000013"), true, true, true, new Guid("d2d2d2d2-e2e2-4123-8123-000000000032"), "جرام" },
                    { new Guid("51ef46f9-40b5-4c83-a7f2-e269a6299c01"), "6291101122", 1m, new Guid("b1b1c1d1-e1f1-4123-8123-000000000011"), true, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "حبة" },
                    { new Guid("dea72494-1986-4210-9815-023d7092ec14"), "6291101155", 48m, new Guid("b2b2c2d2-e2f2-4123-8123-000000000012"), false, true, true, new Guid("d1d1d1d1-e1e1-4123-8123-000000000031"), "كرتون" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("8fc6c991-2122-48c8-b437-6ad6341ac1f7"), new Guid("a9a8f16b-e1d2-4f6f-8091-6f7bc0e5327a"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("9c6ef414-5e4e-4650-b479-cab0ce19cbe0"), new Guid("beb78863-de17-4047-b171-87ba1e235136"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRules_OperationId",
                table: "AccountingRules",
                column: "OperationId");
        }
    }
}
