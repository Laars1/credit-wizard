using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlanners_SemesterTimeSlots_SemesterTimeslotId",
                table: "SemesterPlanners");

            migrationBuilder.RenameColumn(
                name: "SemesterTimeslotId",
                table: "SemesterPlanners",
                newName: "SemesterTimeSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterPlanners_SemesterTimeslotId",
                table: "SemesterPlanners",
                newName: "IX_SemesterPlanners_SemesterTimeSlotId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c05c9ddb-5cbd-4f44-90dd-c423bcb39eff", "AQAAAAIAAYagAAAAEAjUEV/bIHxbzvj9WtAWBku78dIIEdf0zVn/f5uSUGKmCL9qEHrv0hrf3Widmutb5w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlanners_SemesterTimeSlots_SemesterTimeSlotId",
                table: "SemesterPlanners",
                column: "SemesterTimeSlotId",
                principalTable: "SemesterTimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterPlanners_SemesterTimeSlots_SemesterTimeSlotId",
                table: "SemesterPlanners");

            migrationBuilder.RenameColumn(
                name: "SemesterTimeSlotId",
                table: "SemesterPlanners",
                newName: "SemesterTimeslotId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterPlanners_SemesterTimeSlotId",
                table: "SemesterPlanners",
                newName: "IX_SemesterPlanners_SemesterTimeslotId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "edd9e4cf-73d2-4fc3-a794-41fb7aec324f", "AQAAAAIAAYagAAAAEBIWTE1LmS1zEj2RKJbfO5ZrBc56JcQyHh1RL8G8xhekQi1+1yDN7CP3ucf/zV11Jw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterPlanners_SemesterTimeSlots_SemesterTimeslotId",
                table: "SemesterPlanners",
                column: "SemesterTimeslotId",
                principalTable: "SemesterTimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
