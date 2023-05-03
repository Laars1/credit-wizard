using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "59f42b13-96c7-464b-b007-e477db38d6c8", "AQAAAAIAAYagAAAAEJJ3amx3/Y1yHqSdcehLz7fcn5UjPYlJdXNcx3G9nbEAeCKX0vbTd/U+vwhBFHxqOA==" });

            migrationBuilder.InsertData(
                table: "ModulSemesterTimeSlot",
                columns: new[] { "ModulId", "SemesterTimeSlotId" },
                values: new object[] { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ModulSemesterTimeSlot",
                keyColumns: new[] { "ModulId", "SemesterTimeSlotId" },
                keyValues: new object[] { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "65a3026f-60f7-4fd1-aa78-ba126c954d98", "AQAAAAIAAYagAAAAEPpeLxbCxsngunxqReQNLTzfQhbWvnMfKWJhCcFuaK4SrlyPm79TbozFIoN0RcAWoA==" });

            migrationBuilder.InsertData(
                table: "ModulSemesterTimeSlot",
                columns: new[] { "ModulId", "SemesterTimeSlotId" },
                values: new object[] { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") });
        }
    }
}
