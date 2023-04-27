using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedSemesterPlannerModulReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlannerModul_Moduls_ModulId",
                table: "SemesterPlannerModul");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlannerModul_SemesterPlanners_SemesterPlannerId",
                table: "SemesterPlannerModul");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterPlannerModul",
                table: "SemesterPlannerModul");

            migrationBuilder.RenameTable(
                name: "SemesterPlannerModul",
                newName: "SemesterPlannerModuls");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterPlannerModul_ModulId",
                table: "SemesterPlannerModuls",
                newName: "IX_SemesterPlannerModuls_ModulId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterPlannerModuls",
                table: "SemesterPlannerModuls",
                columns: new[] { "SemesterPlannerId", "ModulId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e8eb293-9f8f-4b48-9450-732b7b9e79c4", "AQAAAAIAAYagAAAAEGW3p5ptefApPOa6REsUstN+O03s9X1uHo4dv0pDGhge/taIEpfxjoXggSYivvsmSQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlannerModuls_Moduls_ModulId",
                table: "SemesterPlannerModuls",
                column: "ModulId",
                principalTable: "Moduls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlannerModuls_SemesterPlanners_SemesterPlannerId",
                table: "SemesterPlannerModuls",
                column: "SemesterPlannerId",
                principalTable: "SemesterPlanners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlannerModuls_Moduls_ModulId",
                table: "SemesterPlannerModuls");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlannerModuls_SemesterPlanners_SemesterPlannerId",
                table: "SemesterPlannerModuls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterPlannerModuls",
                table: "SemesterPlannerModuls");

            migrationBuilder.RenameTable(
                name: "SemesterPlannerModuls",
                newName: "SemesterPlannerModul");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterPlannerModuls_ModulId",
                table: "SemesterPlannerModul",
                newName: "IX_SemesterPlannerModul_ModulId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterPlannerModul",
                table: "SemesterPlannerModul",
                columns: new[] { "SemesterPlannerId", "ModulId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c05c9ddb-5cbd-4f44-90dd-c423bcb39eff", "AQAAAAIAAYagAAAAEAjUEV/bIHxbzvj9WtAWBku78dIIEdf0zVn/f5uSUGKmCL9qEHrv0hrf3Widmutb5w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlannerModul_Moduls_ModulId",
                table: "SemesterPlannerModul",
                column: "ModulId",
                principalTable: "Moduls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlannerModul_SemesterPlanners_SemesterPlannerId",
                table: "SemesterPlannerModul",
                column: "SemesterPlannerId",
                principalTable: "SemesterPlanners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
