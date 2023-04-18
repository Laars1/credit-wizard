using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedTotalEtcePoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalEtcsPoints",
                table: "Degrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1d28d68-3f96-4597-9321-93544a3fab7d", "AQAAAAIAAYagAAAAEKQq6bNkm3E0AY/WF8qbJHoAMOgRN12Iy+XRfsFM64A34AvTGomHAiChLcSrKmW59Q==" });

            migrationBuilder.UpdateData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"),
                column: "TotalEtcsPoints",
                value: 180);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalEtcsPoints",
                table: "Degrees");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45a87b70-c0ca-4b53-8016-00b5b72ceb6e", "AQAAAAIAAYagAAAAEEqotivY3CCo6h0f3USxHvr7i/o9iwt1BWkrDQ//AuB0Ff4z/t4iaGAj6/75Pdyphw==" });
        }
    }
}
