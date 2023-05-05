using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Degrees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    TotalEtcsPoints = table.Column<int>(type: "int", nullable: false)
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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EtcsPoints = table.Column<int>(type: "int", nullable: false)
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
                name: "SemesterTimeSlots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timeslot = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterTimeSlots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Prename = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MatriculationNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DegreeModuls",
                columns: table => new
                {
                    ModulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DegreeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeModuls", x => new { x.ModulId, x.DegreeId });
                    table.ForeignKey(
                        name: "FK_DegreeModuls_Degrees_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeModuls_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModulSemesterTimeSlot",
                columns: table => new
                {
                    ModulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterTimeSlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulSemesterTimeSlot", x => new { x.ModulId, x.SemesterTimeSlotId });
                    table.ForeignKey(
                        name: "FK_ModulSemesterTimeSlot_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModulSemesterTimeSlot_SemesterTimeSlots_SemesterTimeSlotId",
                        column: x => x.SemesterTimeSlotId,
                        principalTable: "SemesterTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterPlanners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterTimeSlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterPlanners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_SemesterTimeSlots_SemesterTimeSlotId",
                        column: x => x.SemesterTimeSlotId,
                        principalTable: "SemesterTimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterPlanners_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemesterPlannerModuls",
                columns: table => new
                {
                    SemesterPlannerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModulId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterPlannerModuls", x => new { x.SemesterPlannerId, x.ModulId });
                    table.ForeignKey(
                        name: "FK_SemesterPlannerModuls_Moduls_ModulId",
                        column: x => x.ModulId,
                        principalTable: "Moduls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterPlannerModuls_SemesterPlanners_SemesterPlannerId",
                        column: x => x.SemesterPlannerId,
                        principalTable: "SemesterPlanners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4c01b50b-3ece-4cdd-9e2e-a3594c14e928"), null, "User", null },
                    { new Guid("dcbcfcf5-69e7-430b-ae93-7611aa3ee7bb"), null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "Id", "Description", "Name", "TotalEtcsPoints" },
                values: new object[] { new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), "This degree program is designed to equip students with a blend of business and IT skills, focusing on areas such as business strategy, data analysis, and software development. Graduates are prepared for careers in a variety of industries where technology plays a critical role in business operations.", "Bachelor of Science in Business Information Technology", 180 });

            migrationBuilder.InsertData(
                table: "Moduls",
                columns: new[] { "Id", "Abbreviation", "Description", "EtcsPoints", "Name" },
                values: new object[,]
                {
                    { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), "WWEN", "Web engineering is the process of designing, developing, testing, and maintaining web applications.", 6, "Web Engineering" },
                    { new Guid("2aa07a0c-7f51-4c9d-b968-f6ba201df221"), "BBCS", "Analysis and evaluation of real-world business cases to gain insights and develop problem-solving skills.", 6, "Business Case Studies" },
                    { new Guid("480cc771-16a7-4176-8c2b-9a73c1df7b34"), "WDEN", "An exploration of the impact of digital technologies on business operations.", 6, "Digital Enterprise" },
                    { new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), "WKOM", "Effective communication in a business environment.", 3, "Kommunikation" },
                    { new Guid("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), "WBWL", "Eine Einführung in die Betriebswirtschaftslehre.", 6, "Grundlagen BWL" },
                    { new Guid("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"), "WPR1", "Managing projects from start to finish with an emphasis on planning, execution, and control.", 3, "Projektmanagement" },
                    { new Guid("7eaf3d1c-f214-4115-892b-8e1f1675897b"), "WDDD", "Domain Driven Design is an approach to software development that focuses on understanding and modeling the business domain of an application.", 6, "Domain Driven Design" },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), "WENG", "Developing proficiency in the English language for business communication.", 6, "English" },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), "WBIS", "An introduction to the role of information systems in modern organizations.", 6, "Business Information Systems" },
                    { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), "WGWI", "Introduction to the basics of business informatics.", 6, "Grundlagen WI" },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), "WDDA", "Eine Einführung in die Verwaltung und Analyse von Daten.", 6, "Datenmanagement & Datenanalyse" },
                    { new Guid("eb2dbecc-d0d6-44ef-82eb-34284633ef19"), "WIEN", "Innovation is the process of developing new ideas, products, services, or processes that create value for customers. ntrepreneurship is the process of creating or starting a new business venture in order to make a profit.", 3, "Innovation & Entrepreneurship" },
                    { new Guid("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"), "WACC", "An overview of financial accounting principles and practices.", 6, "Accounting" }
                });

            migrationBuilder.InsertData(
                table: "SemesterTimeSlots",
                columns: new[] { "Id", "Timeslot" },
                values: new object[,]
                {
                    { new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658"), "Frühlingssemester" },
                    { new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835"), "Herbstsemester" }
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DegreeId", "Email", "EmailConfirmed", "Lastname", "LockoutEnabled", "LockoutEnd", "MatriculationNumber", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prename", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5"), 0, "513137db-6285-4ba3-8195-8769db54ee37", new Guid("4b6feabb-8f23-4c91-83d2-1c9b8df465ce"), "hans.mustermann@email.ch", true, "Mustermann", false, null, "11-111-11", "HANS.MUSTERMANN@EMAIL.CH", "HANS.MUSTERMANN@EMAIL.CH", "AQAAAAIAAYagAAAAEKweGONNMVi/EXF0g+xiMJGKFjv3bIsKFFnWFh8qMwE5Xzfg+UriCyP+hzR2eOuC/Q==", null, true, "Hans", null, false, "hans.mustermann@email.ch" });

            migrationBuilder.InsertData(
                table: "DegreeModuls",
                columns: new[] { "DegreeId", "ModulId", "IsRequired" },
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

            migrationBuilder.InsertData(
                table: "ModulSemesterTimeSlot",
                columns: new[] { "ModulId", "SemesterTimeSlotId" },
                values: new object[,]
                {
                    { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("2aa07a0c-7f51-4c9d-b968-f6ba201df221"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("480cc771-16a7-4176-8c2b-9a73c1df7b34"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("6cb76b54-5f27-4b6d-936d-8f6d7b77ce68"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("7eaf3d1c-f214-4115-892b-8e1f1675897b"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("eb2dbecc-d0d6-44ef-82eb-34284633ef19"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("eb2dbecc-d0d6-44ef-82eb-34284633ef19"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") },
                    { new Guid("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658") },
                    { new Guid("f8ccaae7-014d-4ba7-8c24-4249be07b1c1"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("4c01b50b-3ece-4cdd-9e2e-a3594c14e928"), new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5") });

            migrationBuilder.InsertData(
                table: "SemesterPlanners",
                columns: new[] { "Id", "Completed", "SemesterId", "SemesterTimeSlotId", "UserId" },
                values: new object[,]
                {
                    { new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), false, new Guid("26082676-ac5f-4a34-bfea-cebba3889b1f"), new Guid("49de8d00-7b44-4180-ac26-3e919bbeb658"), new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5") },
                    { new Guid("efc28c5e-8908-492e-a6f5-1c7396ab6f02"), false, new Guid("7879d617-ca43-482e-9377-fbd55e2976fa"), new Guid("fae91ab6-7b25-4c5d-bd40-16a79036c835"), new Guid("88fb78eb-7c6e-4d97-a8f9-8300cad558c5") }
                });

            migrationBuilder.InsertData(
                table: "SemesterPlannerModuls",
                columns: new[] { "ModulId", "SemesterPlannerId", "Grade" },
                values: new object[,]
                {
                    { new Guid("19b1c514-fb71-414a-8e0a-1f708e1e136e"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("8f0680b7-68c2-4157-aafc-78c72f63a16f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("b5ed5a5d-21c3-43de-8fb9-9d3a3b99a30f"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("e0a6f205-64b7-42ab-bce3-39f0b3841c71"), new Guid("ee8cdf72-5bea-43c2-a905-3c80192782d1"), null },
                    { new Guid("686e6a0c-7f51-4c9d-b968-f6ba201df221"), new Guid("efc28c5e-8908-492e-a6f5-1c7396ab6f02"), null },
                    { new Guid("6c381c6f-9d9a-4b69-aa13-33a8a94a1277"), new Guid("efc28c5e-8908-492e-a6f5-1c7396ab6f02"), null },
                    { new Guid("b7d16d9e-7a6a-4c11-bcca-4a4c3d4ec864"), new Guid("efc28c5e-8908-492e-a6f5-1c7396ab6f02"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DegreeId",
                table: "AspNetUsers",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeModuls_DegreeId",
                table: "DegreeModuls",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Moduls_Abbreviation",
                table: "Moduls",
                column: "Abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModulSemesterTimeSlot_SemesterTimeSlotId",
                table: "ModulSemesterTimeSlot",
                column: "SemesterTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlannerModuls_ModulId",
                table: "SemesterPlannerModuls",
                column: "ModulId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlanners_SemesterId",
                table: "SemesterPlanners",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlanners_SemesterTimeSlotId",
                table: "SemesterPlanners",
                column: "SemesterTimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterPlanners_UserId_SemesterId",
                table: "SemesterPlanners",
                columns: new[] { "UserId", "SemesterId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DegreeModuls");

            migrationBuilder.DropTable(
                name: "ModulSemesterTimeSlot");

            migrationBuilder.DropTable(
                name: "SemesterPlannerModuls");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Moduls");

            migrationBuilder.DropTable(
                name: "SemesterPlanners");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SemesterTimeSlots");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Degrees");
        }
    }
}
