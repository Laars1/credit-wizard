﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace credit_wizard_api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moduls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moduls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatriculationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DegreeModul",
                columns: table => new
                {
                    ModulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRequried = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeModul", x => new { x.ModulId, x.DegreeId });
                    table.ForeignKey(
                        name: "FK_DegreeModul_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeModul_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterPlanners",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterPlanners", x => new { x.UserId, x.SemesterId });
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), "This degree program is designed to equip students with a blend of business and IT skills, focusing on areas such as business strategy, data analysis, and software development. Graduates are prepared for careers in a variety of industries where technology plays a critical role in business operations.", "Bachelor of Science in Business Information Technology" });

            migrationBuilder.InsertData(
                table: "Moduls",
                columns: new[] { "Id", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), "WWEN", "Web engineering is the process of designing, developing, testing, and maintaining web applications.", "Web Engineering" },
                    { new Guid("2aa07a0c-7f51-4c9d-b968-f6ba201df221"), "BBCS", "Analysis and evaluation of real-world business cases to gain insights and develop problem-solving skills.", "Business Case Studies" },
                    { new Guid("480cc771-16a7-4176-8c2b-9a73c1df7b34"), "WDEN", "An exploration of the impact of digital technologies on business operations.", "Digital Enterprise" },
                    { new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), "WKOM", "Effective communication in a business environment.", "Kommunikation" },
                    { new Guid("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), "WBWL", "Eine Einführung in die Betriebswirtschaftslehre.", "Grundlagen BWL" },
                    { new Guid("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"), "WPR1", "Managing projects from start to finish with an emphasis on planning, execution, and control.", "Projektmanagement" },
                    { new Guid("7eaf3d1c-f214-4115-892b-8e1f1675897b"), "WDDD", "Domain Driven Design is an approach to software development that focuses on understanding and modeling the business domain of an application.", "Domain Driven Design" },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), "WENG", "Developing proficiency in the English language for business communication.", "English" },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), "WBIS", "An introduction to the role of information systems in modern organizations.", "Business Information Systems" },
                    { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), "WGWI", "Introduction to the basics of business informatics.", "Grundlagen WI" },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), "WDDA", "Eine Einführung in die Verwaltung und Analyse von Daten.", "Datenmanagement & Datenanalyse" },
                    { new Guid("eb2dbecc-d0d6-44ef-82eb-34284633ef19"), "WIEN", "Innovation is the process of developing new ideas, products, services, or processes that create value for customers. ntrepreneurship is the process of creating or starting a new business venture in order to make a profit.", "Innovation & Entrepreneurship" },
                    { new Guid("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"), "WACC", "An overview of financial accounting principles and practices.", "Accounting" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { new Guid("185fc9bd-3b34-4ebc-811e-87023698eed0"), 6 },
                    { new Guid("189a7100-1e13-458c-bda4-c9fcbab360fd"), 3 },
                    { new Guid("26082676-ac5f-4a34-bfea-cebba3889b1f"), 2 },
                    { new Guid("78273aa4-0b1f-4dcd-9b6b-d9bf464dae39"), 8 },
                    { new Guid("7879d617-ca43-482e-9377-fbd55e2976fa"), 1 },
                    { new Guid("8c9c8f1e-8484-4d4c-b61e-c7cc905cc1b1"), 4 },
                    { new Guid("addcfd52-30f3-48f4-8e2d-ab7ee149eacf"), 5 },
                    { new Guid("f3f42629-056e-49de-abc9-59948ccf9ee6"), 7 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "MatriculationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"), 0, "aa081316-54d2-4665-bf87-bc84ad231014", "hans.mustermann@email.ch", false, false, null, "11-111-11", null, null, "551a54b35aa91f347d223e0e19d114e0bacbafbf2e879dc839057b90efefbe6f", null, false, null, false, null });

            migrationBuilder.InsertData(
                table: "DegreeModul",
                columns: new[] { "DegreeId", "ModulId", "IsRequried" },
                values: new object[,]
                {
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), false },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("2aa07a0c-7f51-4c9d-b968-f6ba201df221"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("480cc771-16a7-4176-8c2b-9a73c1df7b34"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("7eaf3d1c-f214-4115-892b-8e1f1675897b"), false },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), true },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("eb2dbecc-d0d6-44ef-82eb-34284633ef19"), false },
                    { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), new Guid("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeModul_DegreeId",
                table: "DegreeModul",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Moduls_Abbreviation",
                table: "Moduls",
                column: "Abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlanners_ModulId",
                table: "SemesterPlanners",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlanners_SemesterId",
                table: "SemesterPlanners",
                column: "SemesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeModul");

            migrationBuilder.DropTable(
                name: "SemesterPlanners");

            migrationBuilder.DropTable(
                name: "Degrees");

            migrationBuilder.DropTable(
                name: "Moduls");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
