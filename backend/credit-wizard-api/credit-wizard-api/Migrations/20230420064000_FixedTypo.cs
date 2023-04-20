using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRequried",
                table: "DegreeModul",
                newName: "IsRequired");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "edd9e4cf-73d2-4fc3-a794-41fb7aec324f", "AQAAAAIAAYagAAAAEBIWTE1LmS1zEj2RKJbfO5ZrBc56JcQyHh1RL8G8xhekQi1+1yDN7CP3ucf/zV11Jw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRequired",
                table: "DegreeModul",
                newName: "IsRequried");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f0e02c7-06fe-4955-9f58-2a489329329e", "AQAAAAIAAYagAAAAELRdM0YwQh0yKCbQsLmPMFPg1OILt/zVTZIEKA4fbdeDdSCsG3i0D06WEMLxvcwbyw==" });
        }
    }
}
