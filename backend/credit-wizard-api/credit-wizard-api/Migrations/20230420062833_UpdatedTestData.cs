using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f0e02c7-06fe-4955-9f58-2a489329329e", "AQAAAAIAAYagAAAAELRdM0YwQh0yKCbQsLmPMFPg1OILt/zVTZIEKA4fbdeDdSCsG3i0D06WEMLxvcwbyw==" });

            migrationBuilder.InsertData(
                table: "SemesterPlanners",
                columns: new[] { "Id", "Completed", "SemesterId", "SemesterTimeslotId", "UserId" },
                values: new object[] { new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), false, new Guid("26082676-ac5f-4a34-bfea-cebba3889b1f"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658"), new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5") });

            migrationBuilder.InsertData(
                table: "SemesterPlannerModul",
                columns: new[] { "ModulId", "SemesterPlannerId", "Grade" },
                values: new object[,]
                {
                    { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SemesterPlannerModul",
                keyColumns: new[] { "ModulId", "SemesterPlannerId" },
                keyValues: new object[] { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1") });

            migrationBuilder.DeleteData(
                table: "SemesterPlannerModul",
                keyColumns: new[] { "ModulId", "SemesterPlannerId" },
                keyValues: new object[] { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1") });

            migrationBuilder.DeleteData(
                table: "SemesterPlannerModul",
                keyColumns: new[] { "ModulId", "SemesterPlannerId" },
                keyValues: new object[] { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1") });

            migrationBuilder.DeleteData(
                table: "SemesterPlannerModul",
                keyColumns: new[] { "ModulId", "SemesterPlannerId" },
                keyValues: new object[] { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1") });

            migrationBuilder.DeleteData(
                table: "SemesterPlanners",
                keyColumn: "Id",
                keyValue: new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "172206ea-19e3-4edd-8c7e-1c383459507c", "AQAAAAIAAYagAAAAEP6688WRuWIRtHEdbpXc/9d/NvCREApioBlZb62x6FxrfZdGihI4wqd55Bb6Qg9kXQ==" });
        }
    }
}
