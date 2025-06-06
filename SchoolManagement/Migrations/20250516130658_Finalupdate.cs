﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class Finalupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "FeeTypes",
                columns: table => new
                {
                    FeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<int>(type: "int", nullable: false),
                    IsOptional = table.Column<bool>(type: "bit", nullable: false),
                    ApplicableFromMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypes", x => x.FeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllowMultiple = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "SessionDetailsDtoRaw",
                columns: table => new
                {
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StandardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    FeeAmountPerMonth = table.Column<int>(type: "int", nullable: false),
                    BillingCycle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SessionYears",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAcitve = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionYears", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    AadharFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotosFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentUniqueId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.UniqueId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AppUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Standards",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionYearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standards", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Standards_SessionYears_SessionYearId",
                        column: x => x.SessionYearId,
                        principalTable: "SessionYears",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionFee",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: true),
                    AdmissionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TuitionFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnnualCharges = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActivityFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExaminationFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SportsFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ComputerFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MiscellaneousFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionFee", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_SessionFee_SessionYears_SessionId",
                        column: x => x.SessionId,
                        principalTable: "SessionYears",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionFee_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateTable(
                name: "StandardFees",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    FeeTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFees", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_StandardFees_FeeTypes_FeeTypeId",
                        column: x => x.FeeTypeId,
                        principalTable: "FeeTypes",
                        principalColumn: "FeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardFees_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NearestLandMark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Addresses_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "UniqueId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    SessionYearId = table.Column<int>(type: "int", nullable: false),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotosFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SessionYears_SessionYearId",
                        column: x => x.SessionYearId,
                        principalTable: "SessionYears",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Standards_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standards",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    UniqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationId = table.Column<int>(type: "int", nullable: false),
                    AadhaarNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AadharFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotosFileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeAddressUniqueId = table.Column<int>(type: "int", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CTC = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentUniqueId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.UniqueId);
                    table.ForeignKey(
                        name: "FK_Parents_Addresses_HomeAddressUniqueId",
                        column: x => x.HomeAddressUniqueId,
                        principalTable: "Addresses",
                        principalColumn: "UniqueId");
                    table.ForeignKey(
                        name: "FK_Parents_Relations_RelationId",
                        column: x => x.RelationId,
                        principalTable: "Relations",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parents_Students_StudentUniqueId",
                        column: x => x.StudentUniqueId,
                        principalTable: "Students",
                        principalColumn: "UniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Staff", "STAFF" },
                    { "3", null, "Parent", "PARENT" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "UniqueId", "Name" },
                values: new object[] { 1, "India" });

            migrationBuilder.InsertData(
                table: "FeeTypes",
                columns: new[] { "FeeTypeId", "ApplicableFromMonth", "DueDate", "Frequency", "IsOptional", "IsRecurring", "Name" },
                values: new object[,]
                {
                    { 1, 3, 7, 12, false, false, "Admission Fee" },
                    { 2, 3, 7, 1, false, true, "Tuition Fee" },
                    { 3, 3, 7, 6, false, true, "Semester Fee" },
                    { 4, 3, 7, 12, false, false, "Stationery Fee" },
                    { 5, 3, 0, 1, true, true, "Day Care" },
                    { 6, 6, 0, 12, true, false, "Summer Camping" }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "UniqueId", "AllowMultiple", "RelationName" },
                values: new object[,]
                {
                    { 1, false, "Mother" },
                    { 2, false, "Father" },
                    { 3, false, "GrandFather" },
                    { 4, false, "GrandMother" },
                    { 5, false, "MaternalMother" },
                    { 6, false, "MaternalFather" },
                    { 7, true, "Sister" },
                    { 8, true, "Brother" },
                    { 9, true, "Uncle" },
                    { 10, true, "Aunty" }
                });

            migrationBuilder.InsertData(
                table: "SessionYears",
                columns: new[] { "UniqueId", "CreatedDate", "EndDate", "IsAcitve", "IsDeleted", "SessionName", "StartDate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2022 - 23", new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2023 - 24", new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Session 2024 - 25", new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Session 2025 - 26", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Standards",
                columns: new[] { "UniqueId", "SessionYearId", "StandardName" },
                values: new object[,]
                {
                    { 1, 4, "Nursery" },
                    { 2, 4, "Play Group" },
                    { 3, 4, "L KG" },
                    { 4, 4, "U KG" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "UniqueId", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Andaman and Nicobar Islands" },
                    { 2, 1, "Andhra Pradesh" },
                    { 3, 1, "Arunachal Pradesh" },
                    { 4, 1, "Assam" },
                    { 5, 1, "Bihar" },
                    { 6, 1, "Chandigarh" },
                    { 7, 1, "Chhattisgarh" },
                    { 8, 1, "Dadra and Nagar Haveli" },
                    { 9, 1, "Delhi" },
                    { 10, 1, "Goa" },
                    { 11, 1, "Gujarat" },
                    { 12, 1, "Haryana" },
                    { 13, 1, "Himachal Pradesh" },
                    { 14, 1, "Jammu and Kashmir" },
                    { 15, 1, "Jharkhand" },
                    { 16, 1, "Karnataka" },
                    { 17, 1, "Karnatka" },
                    { 18, 1, "Kerala" },
                    { 19, 1, "Madhya Pradesh" },
                    { 20, 1, "Maharashtra" },
                    { 21, 1, "Manipur" },
                    { 22, 1, "Meghalaya" },
                    { 23, 1, "Mizoram" },
                    { 24, 1, "Nagaland" },
                    { 25, 1, "Odisha" },
                    { 26, 1, "Puducherry" },
                    { 27, 1, "Punjab" },
                    { 28, 1, "Rajasthan" },
                    { 29, 1, "Tamil Nadu" },
                    { 30, 1, "Telangana" },
                    { 31, 1, "Tripura" },
                    { 32, 1, " Uttar Pradesh" },
                    { 33, 1, "Uttarakhand" },
                    { 34, 1, "West Bengal" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "UniqueId", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, "Port Blai", 1 },
                    { 2, "Yemmiganu", 2 },
                    { 3, "Kadir", 2 },
                    { 4, "Rajampe", 2 },
                    { 5, "Tadpatr", 2 },
                    { 6, "Tadepalligude", 2 },
                    { 7, "Chilakaluripe", 2 },
                    { 8, "Chiral", 2 },
                    { 9, "Anakapall", 2 },
                    { 10, "Kaval", 2 },
                    { 11, "Palacol", 2 },
                    { 12, "Sullurpet", 2 },
                    { 13, "Tanuk", 2 },
                    { 14, "Rayachot", 2 },
                    { 15, "Srikalahast", 2 },
                    { 16, "Bapatl", 2 },
                    { 17, "Naidupe", 2 },
                    { 18, "Nagar", 2 },
                    { 19, "Gudu", 2 },
                    { 20, "Vinukond", 2 },
                    { 21, "Narasapura", 2 },
                    { 22, "Nuzvi", 2 },
                    { 23, "Markapu", 2 },
                    { 24, "Ponnu", 2 },
                    { 25, "Kanduku", 2 },
                    { 26, "Bobbil", 2 },
                    { 27, "Rayadur", 2 },
                    { 28, "Visakhapatna", 2 },
                    { 29, "Vijayawad", 2 },
                    { 30, "Guntu", 2 },
                    { 31, "Nellor", 2 },
                    { 32, "Kurnoo", 2 },
                    { 33, "Rajahmundr", 2 },
                    { 34, "Kakinad", 2 },
                    { 35, "Tirupat", 2 },
                    { 36, "Anantapu", 2 },
                    { 37, "Kadap", 2 },
                    { 38, "Vizianagara", 2 },
                    { 39, "Elur", 2 },
                    { 40, "Ongol", 2 },
                    { 41, "Nandya", 2 },
                    { 42, "Machilipatna", 2 },
                    { 43, "Adon", 2 },
                    { 44, "Tenal", 2 },
                    { 45, "Chittoo", 2 },
                    { 46, "Hindupu", 2 },
                    { 47, "Proddatu", 2 },
                    { 48, "Bhimavara", 2 },
                    { 49, "Madanapall", 2 },
                    { 50, "Guntaka", 2 },
                    { 51, "Dharmavara", 2 },
                    { 52, "Gudivad", 2 },
                    { 53, "Srikakula", 2 },
                    { 54, "Narasaraope", 2 },
                    { 55, "Samalko", 2 },
                    { 56, "Jaggaiahpe", 2 },
                    { 57, "Tun", 2 },
                    { 58, "Amalapura", 2 },
                    { 59, "Bheemunipatna", 2 },
                    { 60, "Sattenapall", 2 },
                    { 61, "Venkatagir", 2 },
                    { 62, "Pithapura", 2 },
                    { 63, "Palasa Kasibugg", 2 },
                    { 64, "Parvathipura", 2 },
                    { 65, "Goot", 2 },
                    { 66, "Salu", 2 },
                    { 67, "Macherl", 2 },
                    { 68, "Mandapet", 2 },
                    { 69, "Jammalamadug", 2 },
                    { 70, "Peddapura", 2 },
                    { 71, "Punganu", 2 },
                    { 72, "Nidadavol", 2 },
                    { 73, "Repall", 2 },
                    { 74, "Ramachandrapura", 2 },
                    { 75, "Kovvu", 2 },
                    { 76, "Tiruvur", 2 },
                    { 77, "Uravakond", 2 },
                    { 78, "Narsipatna", 2 },
                    { 79, "Yerraguntl", 2 },
                    { 80, "Pedan", 2 },
                    { 81, "Puttu", 2 },
                    { 82, "Renigunt", 2 },
                    { 83, "Raja", 2 },
                    { 84, "Srisailam Project (Right Flank Colony) Townshi", 2 },
                    { 85, "Pasigha", 3 },
                    { 86, "Naharlagu", 3 },
                    { 87, "Lank", 4 },
                    { 88, "Barpet", 4 },
                    { 89, "Goalpar", 4 },
                    { 90, "Silapatha", 4 },
                    { 91, "Margherit", 4 },
                    { 92, "Mangaldo", 4 },
                    { 93, "Rangi", 4 },
                    { 94, "Mankacha", 4 },
                    { 95, "Lumdin", 4 },
                    { 96, "Nalbar", 4 },
                    { 97, "Nagao", 4 },
                    { 98, "Dibrugar", 4 },
                    { 99, "Silcha", 4 },
                    { 100, "Guwahat", 4 },
                    { 101, "Sibsaga", 4 },
                    { 102, "Karimgan", 4 },
                    { 103, "Tezpu", 4 },
                    { 104, "North Lakhimpu", 4 },
                    { 105, "Diph", 4 },
                    { 106, "Dhubr", 4 },
                    { 107, "Jorha", 4 },
                    { 108, "Bongaigaon Cit", 4 },
                    { 109, "Tinsuki", 4 },
                    { 110, "Marian", 4 },
                    { 111, "Marigao", 4 },
                    { 112, "Maharajgan", 5 },
                    { 113, "Sila", 5 },
                    { 114, "Asargan", 5 },
                    { 115, "Bar", 5 },
                    { 116, "Lakhisara", 5 },
                    { 117, "Nawad", 5 },
                    { 118, "Aurangaba", 5 },
                    { 119, "Buxa", 5 },
                    { 120, "Jehanaba", 5 },
                    { 121, "Jamalpu", 5 },
                    { 122, "Kishangan", 5 },
                    { 123, "Siwa", 5 },
                    { 124, "Arari", 5 },
                    { 125, "Jamu", 5 },
                    { 126, "Sitamarh", 5 },
                    { 127, "Gopalgan", 5 },
                    { 128, "Masaurh", 5 },
                    { 129, "Madhuban", 5 },
                    { 130, "Samastipu", 5 },
                    { 131, "Mokame", 5 },
                    { 132, "Dumrao", 5 },
                    { 133, "Supau", 5 },
                    { 134, "Patn", 5 },
                    { 135, "Chhapr", 5 },
                    { 136, "Begusara", 5 },
                    { 137, "Arra", 5 },
                    { 138, "Darbhang", 5 },
                    { 139, "Bhagalpu", 5 },
                    { 140, "Muzaffarpu", 5 },
                    { 141, "Gay", 5 },
                    { 142, "Purni", 5 },
                    { 143, "Munge", 5 },
                    { 144, "Katiha", 5 },
                    { 145, "Sahars", 5 },
                    { 146, "Dehri-on-Son", 5 },
                    { 147, "Bettia", 5 },
                    { 148, "Sasara", 5 },
                    { 149, "Hajipu", 5 },
                    { 150, "Bagah", 5 },
                    { 151, "Motihar", 5 },
                    { 152, "Roser", 5 },
                    { 153, "Nokh", 5 },
                    { 154, "Sugaul", 5 },
                    { 155, "Makhdumpu", 5 },
                    { 156, "Mane", 5 },
                    { 157, "Rafigan", 5 },
                    { 158, "Marhaur", 5 },
                    { 159, "Pir", 5 },
                    { 160, "Mirgan", 5 },
                    { 161, "Lalgan", 5 },
                    { 162, "Murligan", 5 },
                    { 163, "Motipu", 5 },
                    { 164, "Manihar", 5 },
                    { 165, "Sheoha", 5 },
                    { 166, "Arwa", 5 },
                    { 167, "Forbesgan", 5 },
                    { 168, "BhabUrban Agglomeratio", 5 },
                    { 169, "Narkatiagan", 5 },
                    { 170, "Naugachhi", 5 },
                    { 171, "Sheikhpur", 5 },
                    { 172, "Sultangan", 5 },
                    { 173, "Raxaul Baza", 5 },
                    { 174, "Madhepur", 5 },
                    { 175, "Mahnar Baza", 5 },
                    { 176, "Ramnaga", 5 },
                    { 177, "Rajgi", 5 },
                    { 178, "Sonepu", 5 },
                    { 179, "Sherghat", 5 },
                    { 180, "Warisaligan", 5 },
                    { 181, "Revelgan", 5 },
                    { 182, "Chandigar", 6 },
                    { 183, "Bhilai Naga", 7 },
                    { 184, "Raipu", 7 },
                    { 185, "Bilaspu", 7 },
                    { 186, "Korb", 7 },
                    { 187, "Dur", 7 },
                    { 188, "Jagdalpu", 7 },
                    { 189, "Ambikapu", 7 },
                    { 190, "Raigar", 7 },
                    { 191, "Rajnandgao", 7 },
                    { 192, "Bhatapar", 7 },
                    { 193, "Chirmir", 7 },
                    { 194, "Mahasamun", 7 },
                    { 195, "Dhamtar", 7 },
                    { 196, "Naila Janjgi", 7 },
                    { 197, "Dalli-Rajhar", 7 },
                    { 198, "Manendragar", 7 },
                    { 199, "Mungel", 7 },
                    { 200, "Tilda Newr", 7 },
                    { 201, "Sakt", 7 },
                    { 202, "Silvass", 8 },
                    { 203, "New Delh", 9 },
                    { 204, "Delh", 9 },
                    { 205, "Marmaga", 10 },
                    { 206, "Panaj", 10 },
                    { 207, "Marga", 10 },
                    { 208, "Mapus", 10 },
                    { 209, "Padr", 11 },
                    { 210, "Vyar", 11 },
                    { 211, "Lunawad", 11 },
                    { 212, "Vap", 11 },
                    { 213, "Umret", 11 },
                    { 214, "Rajpipl", 11 },
                    { 215, "Sanan", 11 },
                    { 216, "Rajul", 11 },
                    { 217, "Siho", 11 },
                    { 218, "Mandv", 11 },
                    { 219, "Thangad", 11 },
                    { 220, "Wankane", 11 },
                    { 221, "Limbd", 11 },
                    { 222, "Kapadvan", 11 },
                    { 223, "Petla", 11 },
                    { 224, "Palitan", 11 },
                    { 225, "Lath", 11 },
                    { 226, "Rapa", 11 },
                    { 227, "Songad", 11 },
                    { 228, "Vijapu", 11 },
                    { 229, "Pard", 11 },
                    { 230, "Radhanpu", 11 },
                    { 231, "Mahemdaba", 11 },
                    { 232, "Ranava", 11 },
                    { 233, "Salay", 11 },
                    { 234, "Manavada", 11 },
                    { 235, "Talaj", 11 },
                    { 236, "Vadnaga", 11 },
                    { 237, "Thara", 11 },
                    { 238, "Mans", 11 },
                    { 239, "Umbergao", 11 },
                    { 240, "Amrel", 11 },
                    { 241, "Dees", 11 },
                    { 242, "Dhoraj", 11 },
                    { 243, "Khambha", 11 },
                    { 244, "Mahuv", 11 },
                    { 245, "Anja", 11 },
                    { 246, "Wadhwa", 11 },
                    { 247, "Kesho", 11 },
                    { 248, "Ankleshwa", 11 },
                    { 249, "Savarkundl", 11 },
                    { 250, "Kad", 11 },
                    { 251, "Visnaga", 11 },
                    { 252, "Uplet", 11 },
                    { 253, "Un", 11 },
                    { 254, "Sidhpu", 11 },
                    { 255, "Modas", 11 },
                    { 256, "Viramga", 11 },
                    { 257, "Unjh", 11 },
                    { 258, "Mangro", 11 },
                    { 259, "Ahmedaba", 11 },
                    { 260, "Vadodar", 11 },
                    { 261, "Sura", 11 },
                    { 262, "Rajko", 11 },
                    { 263, "Bhavnaga", 11 },
                    { 264, "Jamnaga", 11 },
                    { 265, "Godhr", 11 },
                    { 266, "Palanpu", 11 },
                    { 267, "Bhu", 11 },
                    { 268, "Valsa", 11 },
                    { 269, "Pata", 11 },
                    { 270, "Verava", 11 },
                    { 271, "Vap", 11 },
                    { 272, "Navsar", 11 },
                    { 273, "Bharuc", 11 },
                    { 274, "Mahesan", 11 },
                    { 275, "Nadia", 11 },
                    { 276, "Anan", 11 },
                    { 277, "Porbanda", 11 },
                    { 278, "Morv", 11 },
                    { 279, "Chhapr", 11 },
                    { 280, "Adala", 11 },
                    { 281, "Sarso", 12 },
                    { 282, "Rani", 12 },
                    { 283, "Bhiwan", 12 },
                    { 284, "Yamunanaga", 12 },
                    { 285, "Panchkul", 12 },
                    { 286, "Sonipa", 12 },
                    { 287, "Bahadurgar", 12 },
                    { 288, "Jin", 12 },
                    { 289, "Sirs", 12 },
                    { 290, "Thanesa", 12 },
                    { 291, "Kaitha", 12 },
                    { 292, "Palwa", 12 },
                    { 293, "Gurgao", 12 },
                    { 294, "Faridaba", 12 },
                    { 295, "Hisa", 12 },
                    { 296, "Rohta", 12 },
                    { 297, "Panipa", 12 },
                    { 298, "Karna", 12 },
                    { 299, "Mandi Dabwal", 12 },
                    { 300, "Gohan", 12 },
                    { 301, "Narwan", 12 },
                    { 302, "Tohan", 12 },
                    { 303, "Fatehaba", 12 },
                    { 304, "Narnau", 12 },
                    { 305, "Hans", 12 },
                    { 306, "Rewar", 12 },
                    { 307, "Ladw", 12 },
                    { 308, "Sohn", 12 },
                    { 309, "Safido", 12 },
                    { 310, "Taraor", 12 },
                    { 311, "Pinjor", 12 },
                    { 312, "Samalkh", 12 },
                    { 313, "Rati", 12 },
                    { 314, "Mahendragar", 12 },
                    { 315, "Charkhi Dadr", 12 },
                    { 316, "Pehow", 12 },
                    { 317, "Shahba", 12 },
                    { 318, "Sola", 13 },
                    { 319, "Sundarnaga", 13 },
                    { 320, "Palampu", 13 },
                    { 321, "Naha", 13 },
                    { 322, "Mand", 13 },
                    { 323, "Shiml", 13 },
                    { 324, "Baramul", 14 },
                    { 325, "Jamm", 14 },
                    { 326, "Srinaga", 14 },
                    { 327, "Sopor", 14 },
                    { 328, "Anantna", 14 },
                    { 329, "Udhampu", 14 },
                    { 330, "KathUrban Agglomeratio", 14 },
                    { 331, "Rajaur", 14 },
                    { 332, "Punc", 14 },
                    { 333, "Madhupu", 15 },
                    { 334, "Chirkund", 15 },
                    { 335, "Chatr", 15 },
                    { 336, "Dumk", 15 },
                    { 337, "Gumi", 15 },
                    { 338, "Simdeg", 15 },
                    { 339, "Musaban", 15 },
                    { 340, "Mihija", 15 },
                    { 341, "Pakau", 15 },
                    { 342, "Patrat", 15 },
                    { 343, "Lohardag", 15 },
                    { 344, "Tenu dam-cum-Kathhar", 15 },
                    { 345, "Ramgar", 15 },
                    { 346, "Saund", 15 },
                    { 347, "Jhumri Tilaiy", 15 },
                    { 348, "Sahibgan", 15 },
                    { 349, "Medininagar (Daltonganj", 15 },
                    { 350, "Chaibas", 15 },
                    { 351, "Dhanba", 15 },
                    { 352, "Ranch", 15 },
                    { 353, "Jamshedpu", 15 },
                    { 354, "Bokaro Steel Cit", 15 },
                    { 355, "Phusr", 15 },
                    { 356, "Adityapu", 15 },
                    { 357, "Deogha", 15 },
                    { 358, "Hazariba", 15 },
                    { 359, "Giridi", 15 },
                    { 360, "Chikkamagalur", 16 },
                    { 361, "Udup", 16 },
                    { 362, "Mandy", 16 },
                    { 363, "Kola", 16 },
                    { 364, "Raayachur", 16 },
                    { 365, "Robertson Pe", 16 },
                    { 366, "Davanager", 16 },
                    { 367, "Belagav", 16 },
                    { 368, "Mangalur", 16 },
                    { 369, "Ballar", 16 },
                    { 370, "Shivamogg", 16 },
                    { 371, "Tumku", 16 },
                    { 372, "Hubli-Dharwa", 16 },
                    { 373, "Bengalur", 16 },
                    { 374, "Rabkavi Banhatt", 16 },
                    { 375, "Shahaba", 16 },
                    { 376, "Sirs", 16 },
                    { 377, "Tiptu", 16 },
                    { 378, "Sindhnu", 16 },
                    { 379, "Yadgi", 16 },
                    { 380, "Ramanagara", 16 },
                    { 381, "Goka", 16 },
                    { 382, "Karwa", 16 },
                    { 383, "Ranebennur", 16 },
                    { 384, "Ranibennu", 16 },
                    { 385, "Ro", 16 },
                    { 386, "Srinivaspu", 16 },
                    { 387, "Sakaleshapur", 16 },
                    { 388, "Shiggao", 16 },
                    { 389, "Sindag", 16 },
                    { 390, "Shrirangapattan", 16 },
                    { 391, "Mudabidr", 16 },
                    { 392, "Navalgun", 16 },
                    { 393, "Magad", 16 },
                    { 394, "Talikot", 16 },
                    { 395, "Mahalingapur", 16 },
                    { 396, "Seda", 16 },
                    { 397, "Shikaripu", 16 },
                    { 398, "Mudalag", 16 },
                    { 399, "Muddebiha", 16 },
                    { 400, "Pavagad", 16 },
                    { 401, "Sindhag", 16 },
                    { 402, "Sandur", 16 },
                    { 403, "Malu", 16 },
                    { 404, "Terda", 16 },
                    { 405, "Maddu", 16 },
                    { 406, "Madhugir", 16 },
                    { 407, "Tekkalakot", 16 },
                    { 408, "Afzalpu", 16 },
                    { 409, "Nargun", 16 },
                    { 410, "Tariker", 16 },
                    { 411, "Malavall", 16 },
                    { 412, "Lakshmeshwa", 16 },
                    { 413, "Ramdur", 16 },
                    { 414, "Nelamangal", 16 },
                    { 415, "Manv", 16 },
                    { 416, "Shahpu", 16 },
                    { 417, "Saundatti-Yellamm", 16 },
                    { 418, "Wad", 16 },
                    { 419, "Sidlaghatt", 16 },
                    { 420, "Sankeshwar", 16 },
                    { 421, "Madiker", 16 },
                    { 422, "Savanu", 16 },
                    { 423, "Lingsugu", 16 },
                    { 424, "Vijayapur", 16 },
                    { 425, "Puttu", 16 },
                    { 426, "Sir", 16 },
                    { 427, "Arsiker", 16 },
                    { 428, "Sagar", 16 },
                    { 429, "Nanjangu", 16 },
                    { 430, "Athn", 16 },
                    { 431, "Sirugupp", 16 },
                    { 432, "Mudho", 16 },
                    { 433, "Mulbaga", 16 },
                    { 434, "Surapur", 16 },
                    { 435, "Sadalag", 16 },
                    { 436, "Mundarg", 16 },
                    { 437, "Adya", 16 },
                    { 438, "Piriyapatn", 16 },
                    { 439, "Mysor", 17 },
                    { 440, "Thrissu", 18 },
                    { 441, "Kolla", 18 },
                    { 442, "Kozhikod", 18 },
                    { 443, "Thiruvananthapura", 18 },
                    { 444, "Koch", 18 },
                    { 445, "Alappuzh", 18 },
                    { 446, "Palakka", 18 },
                    { 447, "Malappura", 18 },
                    { 448, "Ponnan", 18 },
                    { 449, "Taliparamb", 18 },
                    { 450, "Kanhanga", 18 },
                    { 451, "Vatakar", 18 },
                    { 452, "Nedumanga", 18 },
                    { 453, "Ottappala", 18 },
                    { 454, "Kunnamkula", 18 },
                    { 455, "Kottaya", 18 },
                    { 456, "Kasarago", 18 },
                    { 457, "Kannu", 18 },
                    { 458, "Tiru", 18 },
                    { 459, "Kayamkula", 18 },
                    { 460, "Koyiland", 18 },
                    { 461, "Neyyattinkar", 18 },
                    { 462, "Shoranu", 18 },
                    { 463, "Cherthal", 18 },
                    { 464, "Nilambu", 18 },
                    { 465, "Punalu", 18 },
                    { 466, "Perinthalmann", 18 },
                    { 467, "Mattannu", 18 },
                    { 468, "Thodupuzh", 18 },
                    { 469, "Thiruvall", 18 },
                    { 470, "Changanasser", 18 },
                    { 471, "Chalakud", 18 },
                    { 472, "Kodungallu", 18 },
                    { 473, "Pappinisser", 18 },
                    { 474, "Varkal", 18 },
                    { 475, "Pathanamthitt", 18 },
                    { 476, "Paravoo", 18 },
                    { 477, "Attinga", 18 },
                    { 478, "Peringathu", 18 },
                    { 479, "Perumbavoo", 18 },
                    { 480, "Mavelikkar", 18 },
                    { 481, "Mavoo", 18 },
                    { 482, "Muvattupuzh", 18 },
                    { 483, "Adoo", 18 },
                    { 484, "Chittur-Thathamangala", 18 },
                    { 485, "Vaiko", 18 },
                    { 486, "Pala", 18 },
                    { 487, "Puthuppall", 18 },
                    { 488, "Panamatto", 18 },
                    { 489, "Guruvayoo", 18 },
                    { 490, "Panniyannu", 18 },
                    { 491, "Ra", 19 },
                    { 492, "Pal", 19 },
                    { 493, "Pachor", 19 },
                    { 494, "Mhowgao", 19 },
                    { 495, "Narsinghgar", 19 },
                    { 496, "Vijaypu", 19 },
                    { 497, "Manas", 19 },
                    { 498, "Nainpu", 19 },
                    { 499, "Prithvipu", 19 },
                    { 500, "Sohagpu", 19 },
                    { 501, "Maugan", 19 },
                    { 502, "Shamgar", 19 },
                    { 503, "Maharajpu", 19 },
                    { 504, "Multa", 19 },
                    { 505, "Nowrozabad (Khodargama", 19 },
                    { 506, "Niwar", 19 },
                    { 507, "Sausa", 19 },
                    { 508, "Rajgar", 19 },
                    { 509, "Taran", 19 },
                    { 510, "Wara Seon", 19 },
                    { 511, "Rahatgar", 19 },
                    { 512, "Panaga", 19 },
                    { 513, "Manawa", 19 },
                    { 514, "Malaj Khan", 19 },
                    { 515, "Sarangpu", 19 },
                    { 516, "Narsinghgar", 19 },
                    { 517, "Mahidpu", 19 },
                    { 518, "Pasa", 19 },
                    { 519, "Mund", 19 },
                    { 520, "Nepanaga", 19 },
                    { 521, "Seoni-Malw", 19 },
                    { 522, "Rehl", 19 },
                    { 523, "Raise", 19 },
                    { 524, "Laha", 19 },
                    { 525, "Sihor", 19 },
                    { 526, "Nowgon", 19 },
                    { 527, "Mandidee", 19 },
                    { 528, "Umari", 19 },
                    { 529, "Pors", 19 },
                    { 530, "Sanawa", 19 },
                    { 531, "Sabalgar", 19 },
                    { 532, "Maiha", 19 },
                    { 533, "Raghogarh-Vijaypu", 19 },
                    { 534, "Sendhw", 19 },
                    { 535, "Pann", 19 },
                    { 536, "Pipariy", 19 },
                    { 537, "Sidh", 19 },
                    { 538, "Siron", 19 },
                    { 539, "Pandhurn", 19 },
                    { 540, "Shujalpu", 19 },
                    { 541, "Pithampu", 19 },
                    { 542, "Alirajpu", 19 },
                    { 543, "Mandl", 19 },
                    { 544, "Sheopu", 19 },
                    { 545, "Shajapu", 19 },
                    { 546, "Shahdo", 19 },
                    { 547, "Tikamgar", 19 },
                    { 548, "Balagha", 19 },
                    { 549, "Ashok Naga", 19 },
                    { 550, "Seon", 19 },
                    { 551, "Sarn", 19 },
                    { 552, "Sehor", 19 },
                    { 553, "Mhow Cantonmen", 19 },
                    { 554, "Itars", 19 },
                    { 555, "Nagd", 19 },
                    { 556, "Singraul", 19 },
                    { 557, "Moren", 19 },
                    { 558, "Murwara (Katni", 19 },
                    { 559, "Satn", 19 },
                    { 560, "Rew", 19 },
                    { 561, "Mandsau", 19 },
                    { 562, "Neemuc", 19 },
                    { 563, "Vidish", 19 },
                    { 564, "Shivpur", 19 },
                    { 565, "Ganjbasod", 19 },
                    { 566, "Ujjai", 19 },
                    { 567, "Indor", 19 },
                    { 568, "Jabalpu", 19 },
                    { 569, "Gwalio", 19 },
                    { 570, "Bhopa", 19 },
                    { 571, "Saga", 19 },
                    { 572, "Ratla", 19 },
                    { 573, "Ichalkaranj", 20 },
                    { 574, "Parbhan", 20 },
                    { 575, "Akol", 20 },
                    { 576, "Malegao", 20 },
                    { 577, "Nanded-Waghal", 20 },
                    { 578, "Ahmednaga", 20 },
                    { 579, "Latu", 20 },
                    { 580, "Dhul", 20 },
                    { 581, "Kalyan-Dombival", 20 },
                    { 582, "Vasai-Vira", 20 },
                    { 583, "Nashi", 20 },
                    { 584, "Than", 20 },
                    { 585, "Mumba", 20 },
                    { 586, "Nagpu", 20 },
                    { 587, "Pun", 20 },
                    { 588, "Sangl", 20 },
                    { 589, "Mira-Bhayanda", 20 },
                    { 590, "Amravat", 20 },
                    { 591, "Bhiwand", 20 },
                    { 592, "Solapu", 20 },
                    { 593, "Yavatma", 20 },
                    { 594, "Panve", 20 },
                    { 595, "Amalne", 20 },
                    { 596, "Shrirampu", 20 },
                    { 597, "Ako", 20 },
                    { 598, "Pandharpu", 20 },
                    { 599, "Aurangaba", 20 },
                    { 600, "Wardh", 20 },
                    { 601, "Udgi", 20 },
                    { 602, "Nandurba", 20 },
                    { 603, "Achalpu", 20 },
                    { 604, "Osmanaba", 20 },
                    { 605, "Satar", 20 },
                    { 606, "Parl", 20 },
                    { 607, "Washi", 20 },
                    { 608, "Manma", 20 },
                    { 609, "Ambejoga", 20 },
                    { 610, "Lonavl", 20 },
                    { 611, "Wan", 20 },
                    { 612, "Shirpur-Warwad", 20 },
                    { 613, "Malkapu", 20 },
                    { 614, "Talegaon Dabhad", 20 },
                    { 615, "Anjangao", 20 },
                    { 616, "Umre", 20 },
                    { 617, "Sangamne", 20 },
                    { 618, "Uran Islampu", 20 },
                    { 619, "Pusa", 20 },
                    { 620, "Ratnagir", 20 },
                    { 621, "Arv", 20 },
                    { 622, "Manjlegao", 20 },
                    { 623, "Sillo", 20 },
                    { 624, "Wadgaon Roa", 20 },
                    { 625, "Nandur", 20 },
                    { 626, "Waror", 20 },
                    { 627, "Pachor", 20 },
                    { 628, "Tumsa", 20 },
                    { 629, "Palgha", 20 },
                    { 630, "Shegao", 20 },
                    { 631, "Phalta", 20 },
                    { 632, "Oza", 20 },
                    { 633, "Shahad", 20 },
                    { 634, "Yevl", 20 },
                    { 635, "Vit", 20 },
                    { 636, "Umarkhe", 20 },
                    { 637, "Nawapu", 20 },
                    { 638, "Tuljapu", 20 },
                    { 639, "Paitha", 20 },
                    { 640, "Rahur", 20 },
                    { 641, "Nilang", 20 },
                    { 642, "Umarg", 20 },
                    { 643, "Purn", 20 },
                    { 644, "Morsh", 20 },
                    { 645, "Sail", 20 },
                    { 646, "Vaijapu", 20 },
                    { 647, "Tasgao", 20 },
                    { 648, "Murtijapu", 20 },
                    { 649, "Wa", 20 },
                    { 650, "Pulgao", 20 },
                    { 651, "Yawa", 20 },
                    { 652, "Mehka", 20 },
                    { 653, "Mukhe", 20 },
                    { 654, "Rave", 20 },
                    { 655, "Talod", 20 },
                    { 656, "Shrigond", 20 },
                    { 657, "Shird", 20 },
                    { 658, "Pandharkaod", 20 },
                    { 659, "Shiru", 20 },
                    { 660, "Savne", 20 },
                    { 661, "Sasva", 20 },
                    { 662, "Sangol", 20 },
                    { 663, "Partu", 20 },
                    { 664, "Mangrulpi", 20 },
                    { 665, "Riso", 20 },
                    { 666, "Karja", 20 },
                    { 667, "Pe", 20 },
                    { 668, "Ura", 20 },
                    { 669, "Manwat", 20 },
                    { 670, "Satan", 20 },
                    { 671, "Sinna", 20 },
                    { 672, "Pathr", 20 },
                    { 673, "Uchgao", 20 },
                    { 674, "Rajur", 20 },
                    { 675, "Vadgaon Kasb", 20 },
                    { 676, "Tiror", 20 },
                    { 677, "Maha", 20 },
                    { 678, "Lona", 20 },
                    { 679, "Soyagao", 20 },
                    { 680, "Mangalvedh", 20 },
                    { 681, "Sawantwad", 20 },
                    { 682, "Pathard", 20 },
                    { 683, "Mu", 20 },
                    { 684, "Ramte", 20 },
                    { 685, "Paun", 20 },
                    { 686, "Nandgao", 20 },
                    { 687, "Loh", 20 },
                    { 688, "Waru", 20 },
                    { 689, "Mhaswa", 20 },
                    { 690, "Patu", 20 },
                    { 691, "Narkhe", 20 },
                    { 692, "Shendurjan", 20 },
                    { 693, "Mayang Impha", 21 },
                    { 694, "Lilon", 21 },
                    { 695, "Thouba", 21 },
                    { 696, "Impha", 21 },
                    { 697, "Shillon", 22 },
                    { 698, "Tur", 22 },
                    { 699, "Nongstoi", 22 },
                    { 700, "Lungle", 23 },
                    { 701, "Aizaw", 23 },
                    { 702, "Saih", 23 },
                    { 703, "Dimapu", 24 },
                    { 704, "Kohim", 24 },
                    { 705, "Mokokchun", 24 },
                    { 706, "Zunhebot", 24 },
                    { 707, "Tuensan", 24 },
                    { 708, "Wokh", 24 },
                    { 709, "Phulaban", 25 },
                    { 710, "Pattamunda", 25 },
                    { 711, "Sundargar", 25 },
                    { 712, "Kendrapar", 25 },
                    { 713, "Talche", 25 },
                    { 714, "Rajagangapu", 25 },
                    { 715, "Parlakhemund", 25 },
                    { 716, "Byasanaga", 25 },
                    { 717, "Titlagar", 25 },
                    { 718, "Nabarangapu", 25 },
                    { 719, "Sor", 25 },
                    { 720, "Malkangir", 25 },
                    { 721, "Rairangpu", 25 },
                    { 722, "Balangi", 25 },
                    { 723, "Jharsugud", 25 },
                    { 724, "Bhadra", 25 },
                    { 725, "Baripada Tow", 25 },
                    { 726, "Paradi", 25 },
                    { 727, "Bargar", 25 },
                    { 728, "Jatan", 25 },
                    { 729, "Kendujha", 25 },
                    { 730, "Sunabed", 25 },
                    { 731, "Rayagad", 25 },
                    { 732, "Bhawanipatn", 25 },
                    { 733, "Barbi", 25 },
                    { 734, "Dhenkana", 25 },
                    { 735, "Baleshwar Tow", 25 },
                    { 736, "Sambalpu", 25 },
                    { 737, "Pur", 25 },
                    { 738, "Brahmapu", 25 },
                    { 739, "Raurkel", 25 },
                    { 740, "Bhubaneswa", 25 },
                    { 741, "Cuttac", 25 },
                    { 742, "Tarbh", 25 },
                    { 743, "Pondicherr", 26 },
                    { 744, "Yana", 26 },
                    { 745, "Karaika", 26 },
                    { 746, "Mah", 26 },
                    { 747, "Zir", 27 },
                    { 748, "Nakoda", 27 },
                    { 749, "Nanga", 27 },
                    { 750, "Patt", 27 },
                    { 751, "Sirhind Fatehgarh Sahi", 27 },
                    { 752, "Jalandhar Cantt", 27 },
                    { 753, "Rupnaga", 27 },
                    { 754, "Firozpur Cantt", 27 },
                    { 755, "Saman", 27 },
                    { 756, "Nawanshah", 27 },
                    { 757, "Rampura Phu", 27 },
                    { 758, "Qadia", 27 },
                    { 759, "Sujanpu", 27 },
                    { 760, "Pattra", 27 },
                    { 761, "Mukeria", 27 },
                    { 762, "Morinda, Indi", 27 },
                    { 763, "Phillau", 27 },
                    { 764, "Urmar Tand", 27 },
                    { 765, "Longowa", 27 },
                    { 766, "Raiko", 27 },
                    { 767, "Faridko", 27 },
                    { 768, "Muktsa", 27 },
                    { 769, "Rajpur", 27 },
                    { 770, "Mans", 27 },
                    { 771, "Gobindgar", 27 },
                    { 772, "Khara", 27 },
                    { 773, "Gurdaspu", 27 },
                    { 774, "Sangru", 27 },
                    { 775, "Fazilk", 27 },
                    { 776, "Firozpu", 27 },
                    { 777, "Phagwar", 27 },
                    { 778, "Kapurthal", 27 },
                    { 779, "Zirakpu", 27 },
                    { 780, "Kot Kapur", 27 },
                    { 781, "Dhur", 27 },
                    { 782, "Suna", 27 },
                    { 783, "Nabh", 27 },
                    { 784, "Tarn Tara", 27 },
                    { 785, "Malou", 27 },
                    { 786, "Jagrao", 27 },
                    { 787, "Bathind", 27 },
                    { 788, "Jalandha", 27 },
                    { 789, "Amritsa", 27 },
                    { 790, "Patial", 27 },
                    { 791, "Ludhian", 27 },
                    { 792, "Batal", 27 },
                    { 793, "Pathanko", 27 },
                    { 794, "Hoshiarpu", 27 },
                    { 795, "Mohal", 27 },
                    { 796, "Barnal", 27 },
                    { 797, "Mog", 27 },
                    { 798, "Khann", 27 },
                    { 799, "Malerkotl", 27 },
                    { 800, "Talwar", 27 },
                    { 801, "Takhatgar", 28 },
                    { 802, "Pindwar", 28 },
                    { 803, "Mandalgar", 28 },
                    { 804, "Mandaw", 28 },
                    { 805, "Sadulpu", 28 },
                    { 806, "Ton", 28 },
                    { 807, "Sika", 28 },
                    { 808, "Barme", 28 },
                    { 809, "Jodhpu", 28 },
                    { 810, "Jaipu", 28 },
                    { 811, "Bikane", 28 },
                    { 812, "Udaipu", 28 },
                    { 813, "Bharatpu", 28 },
                    { 814, "Pal", 28 },
                    { 815, "Ajme", 28 },
                    { 816, "Bhilwar", 28 },
                    { 817, "Alwa", 28 },
                    { 818, "Ladn", 28 },
                    { 819, "Nimbaher", 28 },
                    { 820, "Ratangar", 28 },
                    { 821, "Nokh", 28 },
                    { 822, "Rajsaman", 28 },
                    { 823, "Suratgar", 28 },
                    { 824, "Makran", 28 },
                    { 825, "Nagau", 28 },
                    { 826, "Sawai Madhopu", 28 },
                    { 827, "Sardarshaha", 28 },
                    { 828, "Sujangar", 28 },
                    { 829, "Sheogan", 28 },
                    { 830, "Rajgarh (Alwar", 28 },
                    { 831, "Naga", 28 },
                    { 832, "Sadr", 28 },
                    { 833, "Todaraising", 28 },
                    { 834, "Sambha", 28 },
                    { 835, "Pranti", 28 },
                    { 836, "Sadulshaha", 28 },
                    { 837, "Todabhi", 28 },
                    { 838, "Reengu", 28 },
                    { 839, "Rajaldesa", 28 },
                    { 840, "Phuler", 28 },
                    { 841, "Mount Ab", 28 },
                    { 842, "Mangro", 28 },
                    { 843, "Shahpur", 28 },
                    { 844, "Raisinghnaga", 28 },
                    { 845, "Rawatsa", 28 },
                    { 846, "Rajakher", 28 },
                    { 847, "Shahpur", 28 },
                    { 848, "Malpur", 28 },
                    { 849, "Nadba", 28 },
                    { 850, "Sanchor", 28 },
                    { 851, "Lakher", 28 },
                    { 852, "Losa", 28 },
                    { 853, "Sri Madhopu", 28 },
                    { 854, "Ramngar", 28 },
                    { 855, "Udaipurwat", 28 },
                    { 856, "Sagwar", 28 },
                    { 857, "Ramganj Mand", 28 },
                    { 858, "Sumerpu", 28 },
                    { 859, "Vijainagar, Ajme", 28 },
                    { 860, "Phalod", 28 },
                    { 861, "Nathdwar", 28 },
                    { 862, "Lachhmangar", 28 },
                    { 863, "Nasiraba", 28 },
                    { 864, "Rajgarh (Churu", 28 },
                    { 865, "Noha", 28 },
                    { 866, "Rawatbhat", 28 },
                    { 867, "Sangari", 28 },
                    { 868, "Pratapgar", 28 },
                    { 869, "Siroh", 28 },
                    { 870, "Lalso", 28 },
                    { 871, "Pipar Cit", 28 },
                    { 872, "Taranaga", 28 },
                    { 873, "Pilibang", 28 },
                    { 874, "Pilan", 28 },
                    { 875, "Merta Cit", 28 },
                    { 876, "Soja", 28 },
                    { 877, "Neem-Ka-Than", 28 },
                    { 878, "Perambalu", 29 },
                    { 879, "Tiruvethipura", 29 },
                    { 880, "Rameshwara", 29 },
                    { 881, "Sivagang", 29 },
                    { 882, "Vadalu", 29 },
                    { 883, "Vellakoi", 29 },
                    { 884, "Sathyamangala", 29 },
                    { 885, "Puliyankud", 29 },
                    { 886, "Nanjikotta", 29 },
                    { 887, "Thuraiyu", 29 },
                    { 888, "Vedaranya", 29 },
                    { 889, "Usilampatt", 29 },
                    { 890, "Thirumangala", 29 },
                    { 891, "Periyakula", 29 },
                    { 892, "Pernampatt", 29 },
                    { 893, "Nandivaram-Guduvancher", 29 },
                    { 894, "Tiruttan", 29 },
                    { 895, "Rasipura", 29 },
                    { 896, "Nellikuppa", 29 },
                    { 897, "Vikramasingapura", 29 },
                    { 898, "Periyasemu", 29 },
                    { 899, "Tiruchendu", 29 },
                    { 900, "Sattu", 29 },
                    { 901, "Sirkal", 29 },
                    { 902, "Vandavas", 29 },
                    { 903, "Uthamapalaya", 29 },
                    { 904, "Vadakkuvalliyu", 29 },
                    { 905, "Tirukalukundra", 29 },
                    { 906, "Tharamangala", 29 },
                    { 907, "Tirukkoyilu", 29 },
                    { 908, "Oddanchatra", 29 },
                    { 909, "Pallada", 29 },
                    { 910, "Manachanallu", 29 },
                    { 911, "Tirupathu", 29 },
                    { 912, "Shenkotta", 29 },
                    { 913, "Vadipatt", 29 },
                    { 914, "Sholingu", 29 },
                    { 915, "Suranda", 29 },
                    { 916, "Sankar", 29 },
                    { 917, "Suriyampalaya", 29 },
                    { 918, "O' Valle", 29 },
                    { 919, "Thammampatt", 29 },
                    { 920, "Sholavanda", 29 },
                    { 921, "Namagiripetta", 29 },
                    { 922, "Tittakud", 29 },
                    { 923, "Pacod", 29 },
                    { 924, "Tharangambad", 29 },
                    { 925, "Natha", 29 },
                    { 926, "Unnamalaikada", 29 },
                    { 927, "P.N.Patt", 29 },
                    { 928, "Thiruthuraipoond", 29 },
                    { 929, "Pallapatt", 29 },
                    { 930, "Ponner", 29 },
                    { 931, "Lalgud", 29 },
                    { 932, "Viswanatha", 29 },
                    { 933, "Polu", 29 },
                    { 934, "Panagud", 29 },
                    { 935, "Uthirameru", 29 },
                    { 936, "Paramakud", 29 },
                    { 937, "Udhagamandala", 29 },
                    { 938, "Aruppukkotta", 29 },
                    { 939, "Arakkona", 29 },
                    { 940, "Tindivana", 29 },
                    { 941, "Virudhunaga", 29 },
                    { 942, "Virudhachala", 29 },
                    { 943, "Srivilliputhu", 29 },
                    { 944, "Nagapattina", 29 },
                    { 945, "Neyveli (TS", 29 },
                    { 946, "Pudukkotta", 29 },
                    { 947, "Tiruchengod", 29 },
                    { 948, "Viluppura", 29 },
                    { 949, "Theni Allinagara", 29 },
                    { 950, "Vaniyambad", 29 },
                    { 951, "Thiruvaru", 29 },
                    { 952, "Gobichettipalaya", 29 },
                    { 953, "Udumalaipetta", 29 },
                    { 954, "Panrut", 29 },
                    { 955, "Namakka", 29 },
                    { 956, "Thiruvallu", 29 },
                    { 957, "Ramanathapura", 29 },
                    { 958, "Pattukkotta", 29 },
                    { 959, "Tirupathu", 29 },
                    { 960, "Sankarankovi", 29 },
                    { 961, "Tenkas", 29 },
                    { 962, "Karu", 29 },
                    { 963, "Valpara", 29 },
                    { 964, "Palan", 29 },
                    { 965, "Tirunelvel", 29 },
                    { 966, "Tiruppu", 29 },
                    { 967, "Ranipe", 29 },
                    { 968, "Tiruchirappall", 29 },
                    { 969, "Coimbator", 29 },
                    { 970, "Sale", 29 },
                    { 971, "Madura", 29 },
                    { 972, "Chenna", 29 },
                    { 973, "Vellor", 29 },
                    { 974, "Nagercoi", 29 },
                    { 975, "Thanjavu", 29 },
                    { 976, "Kancheepura", 29 },
                    { 977, "Erod", 29 },
                    { 978, "Rajapalaya", 29 },
                    { 979, "Sivakas", 29 },
                    { 980, "Pollach", 29 },
                    { 981, "Tiruvannamala", 29 },
                    { 982, "Pallikond", 29 },
                    { 983, "Peravuran", 29 },
                    { 984, "Parangipetta", 29 },
                    { 985, "Pudupattina", 29 },
                    { 986, "Punjaipugalu", 29 },
                    { 987, "Sivagir", 29 },
                    { 988, "Thirupuvana", 29 },
                    { 989, "Padmanabhapura", 29 },
                    { 990, "Mancheria", 30 },
                    { 991, "Adilaba", 30 },
                    { 992, "Mahbubnaga", 30 },
                    { 993, "Khamma", 30 },
                    { 994, "Hyderaba", 30 },
                    { 995, "Waranga", 30 },
                    { 996, "Ramagunda", 30 },
                    { 997, "Karimnaga", 30 },
                    { 998, "Nizamaba", 30 },
                    { 999, "Koratl", 30 },
                    { 1000, "Palwanch", 30 },
                    { 1001, "Tandu", 30 },
                    { 1002, "Sircill", 30 },
                    { 1003, "Mandamarr", 30 },
                    { 1004, "Siddipe", 30 },
                    { 1005, "Sangaredd", 30 },
                    { 1006, "Bellampall", 30 },
                    { 1007, "Wanaparth", 30 },
                    { 1008, "Kagaznaga", 30 },
                    { 1009, "Gadwa", 30 },
                    { 1010, "Miryalagud", 30 },
                    { 1011, "Jagtia", 30 },
                    { 1012, "Suryape", 30 },
                    { 1013, "Bodha", 30 },
                    { 1014, "Nirma", 30 },
                    { 1015, "Kamaredd", 30 },
                    { 1016, "Kothagude", 30 },
                    { 1017, "Nagarkurnoo", 30 },
                    { 1018, "Farooqnaga", 30 },
                    { 1019, "Meda", 30 },
                    { 1020, "Narayanpe", 30 },
                    { 1021, "Bhongi", 30 },
                    { 1022, "Vikaraba", 30 },
                    { 1023, "Jangao", 30 },
                    { 1024, "Bhains", 30 },
                    { 1025, "Bhadrachala", 30 },
                    { 1026, "Kyathampall", 30 },
                    { 1027, "Manugur", 30 },
                    { 1028, "Yelland", 30 },
                    { 1029, "Sadasivpe", 30 },
                    { 1030, "Udaipu", 31 },
                    { 1031, "Pratapgar", 31 },
                    { 1032, "Dharmanaga", 31 },
                    { 1033, "Agartal", 31 },
                    { 1034, "Beloni", 31 },
                    { 1035, "Khowa", 31 },
                    { 1036, "Kailasaha", 31 },
                    { 1037, "Pithoragar", 33 },
                    { 1038, "Ramnaga", 33 },
                    { 1039, "Nainita", 33 },
                    { 1040, "Manglau", 33 },
                    { 1041, "Sitargan", 33 },
                    { 1042, "Nagl", 33 },
                    { 1043, "Paur", 33 },
                    { 1044, "Tehr", 33 },
                    { 1045, "Mussoori", 33 },
                    { 1046, "Rudrapu", 33 },
                    { 1047, "Rishikes", 33 },
                    { 1048, "Srinaga", 33 },
                    { 1049, "Kashipu", 33 },
                    { 1050, "Roorke", 33 },
                    { 1051, "Haldwani-cum-Kathgoda", 33 },
                    { 1052, "Hardwa", 33 },
                    { 1053, "Dehradu", 33 },
                    { 1054, "Bageshwa", 33 },
                    { 1055, "Adr", 34 },
                    { 1056, "Srirampor", 34 },
                    { 1057, "Monoharpu", 34 },
                    { 1058, "Mathabhang", 34 },
                    { 1059, "Asanso", 34 },
                    { 1060, "Siligur", 34 },
                    { 1061, "Kolkat", 34 },
                    { 1062, "Kharagpu", 34 },
                    { 1063, "Raghunathgan", 34 },
                    { 1064, "Naihat", 34 },
                    { 1065, "English Baza", 34 },
                    { 1066, "Baharampu", 34 },
                    { 1067, "Hugli-Chinsura", 34 },
                    { 1068, "Raigan", 34 },
                    { 1069, "Jalpaigur", 34 },
                    { 1070, "Puruli", 34 },
                    { 1071, "Darjilin", 34 },
                    { 1072, "Nabadwi", 34 },
                    { 1073, "Medinipu", 34 },
                    { 1074, "Habr", 34 },
                    { 1075, "Santipu", 34 },
                    { 1076, "Balurgha", 34 },
                    { 1077, "Ranagha", 34 },
                    { 1078, "Bankur", 34 },
                    { 1079, "Tamlu", 34 },
                    { 1080, "AlipurdUrban Agglomeration", 34 },
                    { 1081, "Arambag", 34 },
                    { 1082, "Jhargra", 34 },
                    { 1083, "Sur", 34 },
                    { 1084, "Gangarampu", 34 },
                    { 1085, "Tarakeswa", 34 },
                    { 1086, "Paschim Punropar", 34 },
                    { 1087, "Sonamukh", 34 },
                    { 1088, "PandUrban Agglomeratio", 34 },
                    { 1089, "Mainagur", 34 },
                    { 1090, "Mald", 34 },
                    { 1091, "Panchl", 34 },
                    { 1092, "Raghunathpu", 34 },
                    { 1093, "Kalimpon", 34 },
                    { 1094, "Rampurha", 34 },
                    { 1095, "Tak", 34 },
                    { 1096, "Sainthi", 34 },
                    { 1097, "Murshidaba", 34 },
                    { 1098, "Mema", 34 },
                    { 1100, "Achhnera", 32 },
                    { 1101, "Agra", 32 },
                    { 1102, "Aligarh", 32 },
                    { 1103, "Allahabad", 32 },
                    { 1104, "Amroha", 32 },
                    { 1105, "Azamgarh", 32 },
                    { 1106, "Bahraich", 32 },
                    { 1107, "Chandausi", 32 },
                    { 1108, "Etawah", 32 },
                    { 1109, "Fatehpur Sikri", 32 },
                    { 1110, "Firozabad", 32 },
                    { 1111, "Hapur", 32 },
                    { 1112, "Hardoi ", 32 },
                    { 1113, "Jhansi", 32 },
                    { 1114, "Kalpi", 32 },
                    { 1115, "Kanpur", 32 },
                    { 1116, "Khair", 32 },
                    { 1117, "Laharpur", 32 },
                    { 1118, "Lakhimpur", 32 },
                    { 1119, "Lal Gopalganj Nindaura", 32 },
                    { 1120, "Lalganj", 32 },
                    { 1121, "Lalitpur", 32 },
                    { 1122, "Lar", 32 },
                    { 1123, "Loni", 32 },
                    { 1124, "Lucknow", 32 },
                    { 1125, "Mathura", 32 },
                    { 1126, "Meerut", 32 },
                    { 1127, "Modinagar", 32 },
                    { 1128, "Moradabad", 32 },
                    { 1129, "Nagina", 32 },
                    { 1130, "Najibabad", 32 },
                    { 1131, "Nakur", 32 },
                    { 1132, "Nanpara", 32 },
                    { 1133, "Naraura", 32 },
                    { 1134, "Naugawan Sadat", 32 },
                    { 1135, "Nautanwa", 32 },
                    { 1136, "Nawabganj", 32 },
                    { 1137, "Nehtaur", 32 },
                    { 1138, "Niwai", 32 },
                    { 1139, "Noida", 32 },
                    { 1140, "Noorpur", 32 },
                    { 1141, "Obra", 32 },
                    { 1142, "Orai", 32 },
                    { 1143, "Padrauna", 32 },
                    { 1144, "Palia Kalan", 32 },
                    { 1145, "Parasi", 32 },
                    { 1146, "Phulpur", 32 },
                    { 1147, "Pihani", 32 },
                    { 1148, "Pilibhit", 32 },
                    { 1149, "Pilkhuwa", 32 },
                    { 1150, "Powayan", 32 },
                    { 1151, "Pukhrayan", 32 },
                    { 1152, "Puranpur", 32 },
                    { 1153, "PurqUrban Agglomerationzi", 32 },
                    { 1154, "Purwa", 32 },
                    { 1155, "Rae Bareli", 32 },
                    { 1156, "Rampur", 32 },
                    { 1157, "Rampur Maniharan", 32 },
                    { 1158, "Rasra", 32 },
                    { 1159, "Rath", 32 },
                    { 1160, "Renukoot", 32 },
                    { 1161, "Reoti", 32 },
                    { 1162, "Robertsganj", 32 },
                    { 1163, "Rudauli", 32 },
                    { 1164, "Rudrapur", 32 },
                    { 1165, "Sadabad", 32 },
                    { 1166, "Safipur", 32 },
                    { 1167, "Saharanpur", 32 },
                    { 1168, "Sahaspur", 32 },
                    { 1169, "Sahaswan", 32 },
                    { 1170, "Sahawar", 32 },
                    { 1171, "Sahjanwa", 32 },
                    { 1172, "Saidpur", 32 },
                    { 1173, "Sambhal", 32 },
                    { 1174, "Samdhan", 32 },
                    { 1175, "Samthar", 32 },
                    { 1176, "Sandi", 32 },
                    { 1177, "Sandila", 32 },
                    { 1178, "Sardhana", 32 },
                    { 1179, "Seohara", 32 },
                    { 1180, "Shahabad, Hardoi", 32 },
                    { 1181, "Shahabad, Rampur", 32 },
                    { 1182, "Shahganj", 32 },
                    { 1183, "Shahjahanpur", 32 },
                    { 1184, "Shamli", 32 },
                    { 1185, "Shamsabad, Agra", 32 },
                    { 1186, "Shamsabad, Farrukhabad", 32 },
                    { 1187, "Sherkot", 32 },
                    { 1188, "Shikarpur, Bulandshahr", 32 },
                    { 1189, "Shikohabad", 32 },
                    { 1190, "Shishgarh", 32 },
                    { 1191, "Siana", 32 },
                    { 1192, "Sikanderpur", 32 },
                    { 1193, "Sikandra Rao", 32 },
                    { 1194, "Sikandrabad", 32 },
                    { 1195, "Sirsaganj", 32 },
                    { 1196, "Sirsi", 32 },
                    { 1197, "Sitapur", 32 },
                    { 1198, "Soron", 32 },
                    { 1199, "Sultanpur", 32 },
                    { 1200, "Sumerpur", 32 },
                    { 1201, "SUrban Agglomerationr", 32 },
                    { 1202, "Tanda", 32 },
                    { 1203, "Thakurdwara", 32 },
                    { 1204, "Thana Bhawan", 32 },
                    { 1205, "Tilhar", 32 },
                    { 1206, "Tirwaganj", 32 },
                    { 1207, "Tulsipur", 32 },
                    { 1208, "Tundla", 32 },
                    { 1209, "Ujhani", 32 },
                    { 1210, "Unnao", 32 },
                    { 1211, "Utraula", 32 },
                    { 1212, "Varanasi", 32 },
                    { 1213, "Vrindavan", 32 },
                    { 1214, "Warhapur", 32 },
                    { 1215, "Zaidpur", 32 },
                    { 1216, "Zamania", 32 }
                });

            migrationBuilder.InsertData(
                table: "StandardFees",
                columns: new[] { "UniqueId", "Amount", "DueDate", "FeeTypeId", "StandardId" },
                values: new object[,]
                {
                    { 1, 4000m, null, 1, 2 },
                    { 2, 4000m, null, 2, 2 },
                    { 3, 4000m, null, 3, 2 },
                    { 4, 4000m, null, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_HomeAddressUniqueId",
                table: "Parents",
                column: "HomeAddressUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_RelationId",
                table: "Parents",
                column: "RelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentUniqueId",
                table: "Parents",
                column: "StudentUniqueId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionFee_SessionId",
                table: "SessionFee",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionFee_StandardId",
                table: "SessionFee",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFees_FeeTypeId",
                table: "StandardFees",
                column: "FeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFees_StandardId",
                table: "StandardFees",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Standards_SessionYearId",
                table: "Standards",
                column: "SessionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SessionYearId",
                table: "Students",
                column: "SessionYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StandardId",
                table: "Students",
                column: "StandardId");
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
                name: "Parents");

            migrationBuilder.DropTable(
                name: "SessionDetailsDtoRaw");

            migrationBuilder.DropTable(
                name: "SessionFee");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "StandardFees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "FeeTypes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Standards");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SessionYears");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
