using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataVance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "AccountId", "Address", "Email", "IsActive", "Name", "Phone", "TaxNumber", "VendorCode" },
                values: new object[,]
                {
                    { new Guid("0a00ee58-0654-468a-bf4f-9e3d317aff72"), new Guid("3b07854d-167b-40c5-b0d1-04185b0973b9"), null, null, true, "شركة النور للتوريدات", null, null, "VND-002" },
                    { new Guid("4d0c5474-7cf5-441f-a564-10b6472442d1"), new Guid("c1b56e6a-fb0c-4a05-b224-afe711fed72b"), null, null, true, "مورد تجريبي 1", null, null, "VND-001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("0a00ee58-0654-468a-bf4f-9e3d317aff72"));

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "Id",
                keyValue: new Guid("4d0c5474-7cf5-441f-a564-10b6472442d1"));
        }
    }
}
