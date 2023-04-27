using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae7d2af2-651c-4d24-a583-1cb7f9ee7e06", "AQAAAAIAAYagAAAAEOcpumm47V5kvrxaHfj/FzMImM5J6oyol9gaQOmTRJs30wAuF7G55ZROMKMJssZx/w==" });

            migrationBuilder.InsertData(
                table: "ModulSemesterTimeSlot",
                columns: new[] { "ModulId", "SemesterTimeSlotId" },
                values: new object[] { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModulSemesterTimeSlot",
                keyColumns: new[] { "ModulId", "SemesterTimeSlotId" },
                keyValues: new object[] { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccda6eff-6907-4d67-9899-51389199b96d", "AQAAAAIAAYagAAAAEMCxFXc2do61v66bqP+gjz661/ztbeT41bdTWLa+28rPJqkXCyTOJ35CiVToD8fsLg==" });
        }
    }
}
