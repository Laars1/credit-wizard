using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompletedProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "SemesterPlanners",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "172206ea-19e3-4edd-8c7e-1c383459507c", "AQAAAAIAAYagAAAAEP6688WRuWIRtHEdbpXc/9d/NvCREApioBlZb62x6FxrfZdGihI4wqd55Bb6Qg9kXQ==" });

            migrationBuilder.UpdateData(
                table: "SemesterPlanners",
                keyColumn: "Id",
                keyValue: new Guid("efc28c5e-8908-492e-a6f5-1c7396ab6f02"),
                column: "Completed",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "SemesterPlanners");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1d28d68-3f96-4597-9321-93544a3fab7d", "AQAAAAIAAYagAAAAEKQq6bNkm3E0AY/WF8qbJHoAMOgRN12Iy+XRfsFM64A34AvTGomHAiChLcSrKmW59Q==" });
        }
    }
}
