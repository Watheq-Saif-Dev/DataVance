using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class settingupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRuleLines_AccountingRules_AccountingRuleId",
                table: "AccountingRuleLines");

            migrationBuilder.DropIndex(
                name: "IX_AccountingRuleLines_AccountingRuleId",
                table: "AccountingRuleLines");

            migrationBuilder.DropColumn(
                name: "AccountingRuleId",
                table: "AccountingRuleLines");

            migrationBuilder.EnsureSchema(
                name: "accounting");

            migrationBuilder.EnsureSchema(
                name: "Finance");

            migrationBuilder.RenameTable(
                name: "JournalEntries",
                newName: "JournalEntries",
                newSchema: "Finance");

            migrationBuilder.RenameTable(
                name: "AccountingRules",
                newName: "AccountingRules",
                newSchema: "accounting");

            migrationBuilder.RenameTable(
                name: "AccountingRuleLines",
                newName: "AccountingRuleLines",
                newSchema: "accounting");

            migrationBuilder.RenameTable(
                name: "AccountingOperations",
                newName: "AccountingOperations",
                newSchema: "accounting");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "SystemSettings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SettingKey",
                table: "SystemSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SystemSettings",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "SystemSettings",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "SystemSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystem",
                table: "SystemSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LookupType",
                table: "SystemSettings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EntryNumber",
                schema: "Finance",
                table: "JournalEntries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Finance",
                table: "JournalEntries",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "JournalEntryType",
                schema: "accounting",
                table: "AccountingRules",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EntrySide",
                schema: "accounting",
                table: "AccountingRuleLines",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AmountSourceType",
                schema: "accounting",
                table: "AccountingRuleLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountSourceType",
                schema: "accounting",
                table: "AccountingRuleLines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "accounting",
                table: "AccountingOperations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                schema: "accounting",
                table: "AccountingOperations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSettings_Category_SettingKey",
                table: "SystemSettings",
                columns: new[] { "Category", "SettingKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_EntryNumber",
                schema: "Finance",
                table: "JournalEntries",
                column: "EntryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntries_ReversedEntryId",
                schema: "Finance",
                table: "JournalEntries",
                column: "ReversedEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRules_OperationId",
                schema: "accounting",
                table: "AccountingRules",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRuleLines_RuleId",
                schema: "accounting",
                table: "AccountingRuleLines",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingOperations_Code",
                schema: "accounting",
                table: "AccountingOperations",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRuleLines_AccountingRules_RuleId",
                schema: "accounting",
                table: "AccountingRuleLines",
                column: "RuleId",
                principalSchema: "accounting",
                principalTable: "AccountingRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRules_AccountingOperations_OperationId",
                schema: "accounting",
                table: "AccountingRules",
                column: "OperationId",
                principalSchema: "accounting",
                principalTable: "AccountingOperations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_JournalEntries_ReversedEntryId",
                schema: "Finance",
                table: "JournalEntries",
                column: "ReversedEntryId",
                principalSchema: "Finance",
                principalTable: "JournalEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRuleLines_AccountingRules_RuleId",
                schema: "accounting",
                table: "AccountingRuleLines");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRules_AccountingOperations_OperationId",
                schema: "accounting",
                table: "AccountingRules");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_JournalEntries_ReversedEntryId",
                schema: "Finance",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_SystemSettings_Category_SettingKey",
                table: "SystemSettings");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_EntryNumber",
                schema: "Finance",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntries_ReversedEntryId",
                schema: "Finance",
                table: "JournalEntries");

            migrationBuilder.DropIndex(
                name: "IX_AccountingRules_OperationId",
                schema: "accounting",
                table: "AccountingRules");

            migrationBuilder.DropIndex(
                name: "IX_AccountingRuleLines_RuleId",
                schema: "accounting",
                table: "AccountingRuleLines");

            migrationBuilder.DropIndex(
                name: "IX_AccountingOperations_Code",
                schema: "accounting",
                table: "AccountingOperations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "IsSystem",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "LookupType",
                table: "SystemSettings");

            migrationBuilder.RenameTable(
                name: "JournalEntries",
                schema: "Finance",
                newName: "JournalEntries");

            migrationBuilder.RenameTable(
                name: "AccountingRules",
                schema: "accounting",
                newName: "AccountingRules");

            migrationBuilder.RenameTable(
                name: "AccountingRuleLines",
                schema: "accounting",
                newName: "AccountingRuleLines");

            migrationBuilder.RenameTable(
                name: "AccountingOperations",
                schema: "accounting",
                newName: "AccountingOperations");

            migrationBuilder.AlterColumn<string>(
                name: "ValueType",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SettingKey",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "EntryNumber",
                table: "JournalEntries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JournalEntries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "JournalEntryType",
                table: "AccountingRules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "EntrySide",
                table: "AccountingRuleLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<int>(
                name: "AmountSourceType",
                table: "AccountingRuleLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "AccountSourceType",
                table: "AccountingRuleLines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "AccountingRuleId",
                table: "AccountingRuleLines",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountingOperations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "AccountingOperations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRuleLines_AccountingRuleId",
                table: "AccountingRuleLines",
                column: "AccountingRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRuleLines_AccountingRules_AccountingRuleId",
                table: "AccountingRuleLines",
                column: "AccountingRuleId",
                principalTable: "AccountingRules",
                principalColumn: "Id");
        }
    }
}
