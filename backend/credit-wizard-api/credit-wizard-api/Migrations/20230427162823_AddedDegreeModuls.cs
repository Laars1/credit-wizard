using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDegreeModuls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeModul_Degrees_DegreeId",
                table: "DegreeModul");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeModul_Moduls_ModulId",
                table: "DegreeModul");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DegreeModul",
                table: "DegreeModul");

            migrationBuilder.RenameTable(
                name: "DegreeModul",
                newName: "DegreeModuls");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeModul_DegreeId",
                table: "DegreeModuls",
                newName: "IX_DegreeModuls_DegreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DegreeModuls",
                table: "DegreeModuls",
                columns: new[] { "ModulId", "DegreeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ccda6eff-6907-4d67-9899-51389199b96d", "AQAAAAIAAYagAAAAEMCxFXc2do61v66bqP+gjz661/ztbeT41bdTWLa+28rPJqkXCyTOJ35CiVToD8fsLg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeModuls_Degrees_DegreeId",
                table: "DegreeModuls",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeModuls_Moduls_ModulId",
                table: "DegreeModuls",
                column: "ModulId",
                principalTable: "Moduls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeModuls_Degrees_DegreeId",
                table: "DegreeModuls");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeModuls_Moduls_ModulId",
                table: "DegreeModuls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DegreeModuls",
                table: "DegreeModuls");

            migrationBuilder.RenameTable(
                name: "DegreeModuls",
                newName: "DegreeModul");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeModuls_DegreeId",
                table: "DegreeModul",
                newName: "IX_DegreeModul_DegreeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DegreeModul",
                table: "DegreeModul",
                columns: new[] { "ModulId", "DegreeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e8eb293-9f8f-4b48-9450-732b7b9e79c4", "AQAAAAIAAYagAAAAEGW3p5ptefApPOa6REsUstN+O03s9X1uHo4dv0pDGhge/taIEpfxjoXggSYivvsmSQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeModul_Degrees_DegreeId",
                table: "DegreeModul",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeModul_Moduls_ModulId",
                table: "DegreeModul",
                column: "ModulId",
                principalTable: "Moduls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
