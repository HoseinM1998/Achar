using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Achar.Infra.Db.SqLServer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Score = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Experts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HomeServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeServices_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpertSubCategory",
                columns: table => new
                {
                    ExpertsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpertSubCategory", x => new { x.ExpertsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ExpertSubCategory_Experts_ExpertsId",
                        column: x => x.ExpertsId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpertSubCategory_SubCategory_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequesteForTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AcceptedExpertId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Experts_AcceptedExpertId",
                        column: x => x.AcceptedExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_HomeServices_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "HomeServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    BidPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Expert", "EXPERT" },
                    { 3, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, null, "9c38d176-4ddf-4c5f-85e8-41941e2e059c", "Admin@gmail.com", false, "ادمین", "ادمین", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEFja0ODf+tEwEVdS+D+vkndDci9Istug/wUeeTDGUDnKqRzknFeX4dj+t/zyDP5wHA==", "09913466961", false, "/userassets/img/1.png", "e0c4fdd9-68a3-4d22-b868-a8eadd8571d6", false, "Admin@gmail.com" },
                    { 2, 0, null, "ce07de32-2668-4116-a839-05c5e921fb2a", "Hosein@gmail.com", false, "حسین", "مصلحی", false, null, "HOSEIN@GMAIL.COM", "HOSEIN@GMAIL.COM", "AQAAAAIAAYagAAAAEL0C3pzMCdcArHAnytOmUzDVUTxdry+QHYlvkSS6/kt08tubWeNtbBV/1F8oDB5b6A==", "09913466961", false, "/userassets/img/1.png", "cb69c829-5308-4168-89dc-5678efd24c16", false, "Hosein@gmail.com" },
                    { 3, 0, null, "37943164-ac2a-4215-9e3f-a9c088b32e96", "Javad@gmail.com", false, "جواد", "مرادی", false, null, "JAVAD@GMAIL.COM", "JAVAD@GMAIL.COM", "AQAAAAIAAYagAAAAEHdV6LL88uDhV+pmxgRaqRWZ9NGeVli2Wm/ZeyPh1e9OYsaoCOFtZK8/zDns6J/yJg==", "09913466961", false, "/userassets/img/1.png", "7d50ab28-aa7e-4708-9cbe-bdc443ffdb63", false, "Javad@gmail.com" },
                    { 4, 0, null, "dc37540d-e143-46ad-a6f2-c41e685bcfb8", "Aref@gmail.com", false, "عارف", "بهمنی", false, null, "AREF@GMAIL.COM", "AREF@GMAIL.COM", "AQAAAAIAAYagAAAAEDVTUmtbUm2M7qJjJLvPiQrDmhpaUZ8I6FSS7MbAd4rmHOsh0flrWzSCVCLpFmq6JA==", "09913466961", false, "/userassets/img/1.png", "ed5c3227-756e-4b26-b4b9-2a602975d1ba", false, "Aref@gmail.com" },
                    { 5, 0, null, "41a71055-d3b9-44c0-a034-555e5d550eda", "Saeid@gmail.com", false, "سعید", "لک‌", false, null, "SAEID@GMAIL.COM", "SAEID@GMAIL.COM", "AQAAAAIAAYagAAAAEKhNLRkLuYWiHMvlz/WODPhRkn5D0W9T02UD+KwNp5j1m2ffy7Zk8vQx0QfaMlLX5Q==", "09913466961", false, "/userassets/img/1.png", "dc52d276-8b9e-47f2-a70c-d9fc40991528", false, "Saeid@gmail.com" },
                    { 6, 0, null, "1b36c226-d692-4dce-9c7a-7126ff22e40d", "Sahar@gmail.com", false, "سحر", null, false, null, "SAHAR@GMAIL.COM", "SAHAR@GMAIL.COM", "AQAAAAIAAYagAAAAEEeR0r2w2hTR1i0bUuHqUSxNjwCUS97uSo5JH+ri+gIe08z0LraglY7gNBSFOWhh7Q==", "09913466961", false, "/userassets/img/1.png", "e79d9104-0e0e-491c-95e2-333503a8c9a4", false, "Sahar@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Image", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(3240), "/assets/img/category/TamizCari-con.png.png", "تمیزکاری" },
                    { 2, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4036), "/assets/img/category/Sakhtman-icon.png", "ساختمان " },
                    { 3, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4039), "/assets/img/category/Tamirat-icon.png", "تعمیرات اشیا" },
                    { 4, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4041), "/assets/img/category/Asbabkeshi-icon.png", " اسباب کشی وحمل بار " },
                    { 5, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4042), "/assets/img/category/Khodro-icon.png", "خودرو " },
                    { 6, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4043), "/assets/img/category/Salamat-icon.png", " سلامت وزیبایی " },
                    { 7, new DateTime(2025, 2, 13, 19, 39, 18, 589, DateTimeKind.Local).AddTicks(4045), "/assets/img/category/Sazeman-icon.png", "سازمان ها و مجتمع ها " }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreateAt", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 13, 19, 39, 18, 592, DateTimeKind.Local).AddTicks(9647), "تهران" },
                    { 2, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(151), "مشهد" },
                    { 3, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(154), "اصفهان" },
                    { 4, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(157), "شیراز" },
                    { 5, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(158), "تبریز" },
                    { 6, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(163), "کرج" },
                    { 7, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(258), "قم" },
                    { 8, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(259), "اهواز" },
                    { 9, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(260), "رشت" },
                    { 10, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(263), "کرمانشاه" },
                    { 11, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(264), "زاهدان" },
                    { 12, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(265), "ارومیه" },
                    { 13, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(266), "یزد" },
                    { 14, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(267), "همدان" },
                    { 15, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(268), "قزوین" },
                    { 16, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(270), "سنندج" },
                    { 17, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(271), "بندرعباس" },
                    { 18, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(273), "زنجان" },
                    { 19, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(274), "ساری" },
                    { 20, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(275), "بوشهر" },
                    { 21, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(276), "مازندران" },
                    { 22, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(277), "گرگان" },
                    { 23, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(278), "کرمان" },
                    { 24, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(279), "خرم آباد" },
                    { 25, new DateTime(2025, 2, 13, 19, 39, 18, 593, DateTimeKind.Local).AddTicks(280), "سمنان" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "ApplicationUserId", "CreateAt" },
                values: new object[] { 1, 1, new DateTime(2025, 2, 13, 19, 39, 18, 586, DateTimeKind.Local).AddTicks(5013) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CreateAt", "Gender", "Street" },
                values: new object[,]
                {
                    { 1, 2, 6, new DateTime(2025, 2, 13, 19, 39, 18, 596, DateTimeKind.Local).AddTicks(674), null, null },
                    { 2, 3, 1, new DateTime(2025, 2, 13, 19, 39, 18, 596, DateTimeKind.Local).AddTicks(1322), null, null },
                    { 3, 4, 1, new DateTime(2025, 2, 13, 19, 39, 18, 596, DateTimeKind.Local).AddTicks(1326), null, null }
                });

            migrationBuilder.InsertData(
                table: "Experts",
                columns: new[] { "Id", "ApplicationUserId", "CityId", "CreateAt", "Gender", "Score", "Street" },
                values: new object[,]
                {
                    { 1, 5, null, new DateTime(2025, 2, 13, 19, 39, 18, 598, DateTimeKind.Local).AddTicks(368), null, null, null },
                    { 2, 6, null, new DateTime(2025, 2, 13, 19, 39, 18, 598, DateTimeKind.Local).AddTicks(860), null, null, null }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "CreateAt", "Image", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(2191), "/assets/img/subcategory/Tamiz-1-mage.png", "نظافت و پذیرایی" },
                    { 2, 1, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3089), "/assets/img/subcategory/Tamiz-2-mage.png", "شستشو" },
                    { 3, 1, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3092), "/assets/img/subcategory/Tamiz-3-mage.png", " آشپزی" },
                    { 4, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3094), "/assets/img/subcategory/Sakhtman-1-image.png", "سرمایش و گرمایش" },
                    { 5, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3096), "/assets/img/subcategory/Sakhtman-2-image.png", "تعمیرات ساختمان" },
                    { 6, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3098), "/assets/img/subcategory/Sakhtman-3-image.png", "لوله کشی" },
                    { 7, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3099), "/assets/img/subcategory/Sakhtman-4-image.png", "برقکاری" },
                    { 8, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3101), "/assets/img/subcategory/Sakhtman-6-image.png", "چوب وکابینت" },
                    { 9, 2, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3102), "/assets/img/subcategory/Sakhtman-7-image.png", "خدمات شیشه ای ساختمان" },
                    { 10, 3, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3104), "/assets/img/subcategory/", "سرمایش وگرمایش" },
                    { 11, 3, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3105), "/assets/img/subcategory/Tamirat-1-image.png", "نصب و تعمیرات لوارم خانگی" },
                    { 12, 3, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3107), "/assets/img/subcategory/Tamirat-2-image.png", "خدمات کامپیوتری" },
                    { 13, 3, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3108), "/assets/img/subcategory/Tamirat-3-image.png", "تعمیرات موبایل" },
                    { 14, 4, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3110), "/assets/img/subcategory/asbabkeshi.jpg", "باربری و جابه جایی" },
                    { 15, 5, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3111), "/assets/img/subcategoryKhodro-1-image.png/", "خدمات و تعمیرات خودرو" },
                    { 16, 5, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3113), "/assets/img/subcategory/Khodro-2-image.png", "کارواش و دیتلینگ" },
                    { 17, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3114), "/assets/img/subcategory/Salamat-1-image.png", "زیبایی بانوان" },
                    { 18, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3116), "/assets/img/subcategory/Salamat-2-image.png", "پزشکی و پرستاری" },
                    { 19, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3117), "/assets/img/subcategory/Salamat-3-image.png", "حیوانات خانگی" },
                    { 20, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3118), "/assets/img/subcategory/Salamat-4-image.png", "مشاوره" },
                    { 21, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3120), "/assets/img/subcategory/Salamat-5-image.png", "پیرایش و زیبایی آقایان" },
                    { 22, 6, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3121), "/assets/img/subcategory/Salamat-6-image.png", "تندرستی و ورزش" },
                    { 23, 7, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3123), "/assets/img/subcategory/Sazeman-1-image.png", "خدمات شرکتی" },
                    { 24, 7, new DateTime(2025, 2, 13, 19, 39, 18, 607, DateTimeKind.Local).AddTicks(3124), "/assets/img/subcategory/Sazeman-1-image.png", "تامین نیروی انسانی" }
                });

            migrationBuilder.InsertData(
                table: "HomeServices",
                columns: new[] { "Id", "BasePrice", "CreateAt", "Description", "ImageSrc", "ShortDescription", "SubCategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(1228), "سرویس عادی نظافت شامل تمیزکاری کلی محیط، گردگیری سطوح، جارو و تی کشی است. این سرویس برای حفظ نظافت روزمره و ایجاد فضایی پاک و مرتب ارائه میشود.", "/assets/img/homeservice/1.jpg", null, 1, "سرویس عادی نظافت" },
                    { 2, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2415), "سرویس ویژه نظافت شامل تمیزکاری عمیق و تخصصی با استفاده از مواد و تجهیزات حرفه ای است. این سرویس برای پاک سازی کامل و ضدعفونی محیط های مسکونی و اداری ارائه میشود.", "/assets/img/homeservice/2.jpg", null, 1, "سرویس وِیژه نظافت" },
                    { 3, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2419), "سرویس نظافت راه پله شامل جارو و تی کشی پله ها، پاکسازی نرده ها، دستگیره ها و ورودی ساختمان است. این سرویس به حفظ تمیزی و زیبایی مشاعات کمک می کند.", "/assets/img/homeservice/3.jpg", null, 1, "نظافت راه پله" },
                    { 4, 1500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2421), "سرویس پذیرایی شامل چیدمان، سرو غذا و نوشیدنی، نظافت میزها و رسیدگی به مهمانان است این سرویس برای مراسم، مهمانی ها و جلسات ارائه میشود", "/assets/img/homeservice/4.jpg", null, 1, "پذیرایی" },
                    { 5, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2423), "سرویس کارگر ساده شامل انجام امور عمومی مانند جابه جایی وسایل، کمک در نظافت، انبارداری و سایر کارهای دستی است. این سرویس برای مصارف خانگی و صنعتی ارائه میشود.", "/assets/img/homeservice/5.jpg", null, 1, "کارگرساده" },
                    { 6, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2425), "سرویس فینگرفود شامل تهیه و سرو انواع خوراکیهای لقمهای شیک و خوشمزه برای مهمانیها، مراسم و جلسات است. این سرویس تنوعی از طعمها را با دیزاینی جذاب ارائه میدهد.", "/assets/img/homeservice/6.jpg", null, 3, "فینگرفود" },
                    { 7, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2427), "سرویس فست  شامل تهیه و ارائه انواع غذاهای سریع و لذیذ مانند برگر، پیتزا، ساندویچ و سیب  سرخ  است. این سرویس برای مجالس، مهمانی  و رویدادهای مختلف ارائه میشود.", "/assets/img/homeservice/7.jpg", null, 3, "فست فود" },
                    { 8, 250000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2441), "سرویس غذای ایرانی شامل تهیه و سرو انواع غذاهای سنتی و اصیل ایرانی مانند کباب، قورمه ، قیمه و باقالی  است. این سرویس برای مهمانی ، مراسم و رویدادهای خاص ارائه میشود.", "/assets/img/homeservice/8.jpg", null, 3, "غذای ایرانی" },
                    { 9, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2443), "سرویس تعمیر و نگهداری پکیج شامل عیب ، رسوب ، تنظیم فشار، هواگیری و تعمیر قطعات معیوب است. این سرویس برای بهبود عملکرد و افزایش عمر مفید پکیج ارائه میشود.", "/assets/img/homeservice/9.jpg", null, 4, "تعمیر و سرویس پکیج" },
                    { 10, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2445), "سرویس تعمیر و نگهداری آبگرمکن شامل عیب ، رسوب ، تنظیم شعله، تعویض قطعات معیوب و هواگیری است. این سرویس برای بهبود عملکرد و افزایش عمر مفید آبگرمکن ارائه میشود.", "/assets/img/homeservice/10.jpg", null, 4, "تعمیر و سرویس آبگرمکن" },
                    { 11, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2447), "سرویس تعمیر و نگهداری فن شامل تمیز کردن فیلترها، بررسی عملکرد موتور، تنظیم دما و فشار آب، و عیب یابی سیستم برقی است. این سرویس به بهبود عملکرد فن کوئل و افزایش کارایی سیستم تهویه کمک میکند.", "/assets/img/homeservice/11.jpg", null, 4, "تعمیر و سرویس فن کویل" },
                    { 12, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2449), "سرویس تعمیر و نگهداری کولرگازی و داکت اسپلیت شامل بررسی عملکرد کمپرسور، تمیز کردن فیلترها، شارژ گاز، عیب یابی قطعات الکتریکی و مکانیکی، و تنظیم دما است. این سرویس به بهبود عملکرد و طول عمر دستگاه ها کمک میکند.", "/assets/img/homeservice/12.jpg", null, 4, "تعمیر کولرگازی و داکت اسپلیت" },
                    { 13, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2450), "سرویس تعمیر و نگهداری کولر آبی شامل تمیز کردن پوشال‌ها، بررسی موتور و پمپ آب، تنظیم شیب لوله‌ها، تعویض قطعات فرسوده و تنظیم عملکرد فن است. این سرویس به بهبود کارایی کولر و افزایش عمر مفید آن کمک می‌کند.", "/assets/img/homeservice/13.jpg", null, 4, "تعمیر و سرویس کولر آبی" },
                    { 14, 3000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2452), "سرویس سنگ‌کاری شامل نصب، ترمیم و صیقل دادن انواع سنگ‌ها در کف، دیوار و سطوح مختلف است. این سرویس برای زیبا‌سازی و استحکام فضاهای داخلی و خارجی مانند ساختمان‌ها، حیاط‌ها و محوطه‌های عمومی ارائه می‌شود.", "/assets/img/homeservice/14.jpg", null, 5, "سنگ کاری" },
                    { 15, 3000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2454), "سرویس نقاشی ساختمان شامل رنگ‌آمیزی دیوارها، سقف‌ها، درب‌ها و پنجره‌ها با استفاده از رنگ‌های مرغوب و تکنیک‌های حرفه‌ای است. این سرویس برای ایجاد ظاهری زیبا و تازه برای فضاهای داخلی و خارجی ساختمان ارائه می‌شود.", "/assets/img/homeservice/15.jpg", null, 5, "نقاشی ساختمان" },
                    { 16, 250000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2456), "سرویس نصب کاغذ دیواری شامل اندازه‌گیری دقیق دیوارها، انتخاب و نصب کاغذ دیواری با طراحی و رنگ دلخواه است. این سرویس برای زیباسازی فضاهای داخلی و ایجاد جلوه‌ای خاص و شیک در خانه‌ها و ادارات ارائه می‌شود.", "/assets/img/homeservice/16.jpg", null, 5, "نصب کاغذ دیواری" },
                    { 17, 250000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2458), "سرویس دوخت و نصب پرده شامل طراحی، اندازه‌گیری، دوخت پرده متناسب با دکوراسیون و نصب حرفه‌ای آن است. این سرویس برای زیباسازی و تنظیم نور فضاهای مسکونی و اداری ارائه می‌شود.", "/assets/img/homeservice/17.jpg", null, 5, "دوخت و نصب پرده" },
                    { 18, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2459), "سرویس بنایی شامل ساخت، تعمیر و بازسازی بخش‌های مختلف ساختمان مانند دیوارچینی، کف‌سازی، گچ‌کاری و سیمان‌کاری است. این سرویس برای مقا‌م‌سازی و زیباسازی فضاهای مسکونی، اداری و تجاری ارائه می‌شود.", "/assets/img/homeservice/18.jpg", null, 5, "بنایی" },
                    { 19, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2461), "سرویس کلیدسازی شامل ساخت انواع کلید، باز کردن قفل‌های درب، تعویض و تعمیر قفل، و نصب انواع قفل ایمنی است. این سرویس به‌صورت فوری و در محل ارائه می‌شود.", "/assets/img/homeservice/19.jpg", null, 5, "کلیدسازی" },
                    { 20, 150000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2463), "سرویس نصب و تعمیرات شیرآلات شامل نصب انواع شیرآلات بهداشتی، تعویض واشر و کارتریج، رفع نشتی و تنظیم فشار آب است. این سرویس برای بهبود عملکرد و افزایش دوام سیستم لوله‌کشی ارائه می‌شود.", "/assets/img/homeservice/20.jpg", null, 6, "نصب و تعمیرات شیرالات" },
                    { 21, 150000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2465), "سرویس تخلیه چاه و لوله‌بازکنی شامل رفع گرفتگی لوله‌ها، تخلیه چاه‌های فاضلاب، رسوب‌زدایی و رفع بوی نامطبوع با استفاده از تجهیزات تخصصی است. این سرویس به بهبود عملکرد سیستم فاضلاب و جلوگیری از مشکلات جدی کمک می‌کند.", "/assets/img/homeservice/21.jpg", null, 6, "تخلیه چاه ولوله باز کنی" },
                    { 22, 250000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2476), "سرویس پمپ و منبع آب شامل نصب، تعمیر و سرویس انواع پمپ‌های آب، تنظیم فشار، هواگیری و عیب‌یابی مخازن آب است. این سرویس برای افزایش راندمان سیستم آبرسانی و جلوگیری از افت فشار ارائه می‌شود.", "/assets/img/homeservice/22.jpg", null, 6, "پمپ و منبع اب" },
                    { 23, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2478), "سرویس تشخیص و ترمیم ترکیدگی لوله شامل شناسایی محل نشتی با دستگاه‌های دقیق، تعمیر یا تعویض لوله‌های آسیب‌دیده و جلوگیری از هدررفت آب است. این سرویس برای حفظ سلامت سیستم لوله‌کشی و کاهش هزینه‌های ناشی از نشتی ارائه می‌شود.", "/assets/img/homeservice/23.jpg", null, 6, "تشخیص و ترمیم ترکیدگی لوله" },
                    { 24, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2480), "سرویس لوله‌کشی گاز شامل طراحی، نصب، تعمیر و تست ایمنی لوله‌های گاز در ساختمان‌های مسکونی و تجاری است. این سرویس با رعایت استانداردهای ایمنی برای تأمین گاز مطمئن و پایدار ارائه می‌شود.", "/assets/img/homeservice/24.jpg", null, 6, "لوله کشی گاز" },
                    { 25, 400000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2482), "سرویس نصب و تعمیر سینک ظرفشویی شامل نصب انواع سینک، تعویض اتصالات، رفع نشتی، تنظیم شیب فاضلاب و آب‌بندی صحیح است. این سرویس برای بهبود عملکرد و جلوگیری از مشکلات نشتی و گرفتگی ارائه می‌شود.", "/assets/img/homeservice/25.jpg", null, 7, "نصب و تعمیر سینک ظرفشویی" },
                    { 26, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2484), "سرویس سیم‌کشی و کابل‌کشی شامل طراحی، اجرا، تعمیر و ارتقای سیستم‌های برق‌رسانی در ساختمان‌های مسکونی، اداری و صنعتی است. این سرویس با رعایت استانداردهای ایمنی برای تأمین برق پایدار و مطمئن ارائه می‌شود.", "/assets/img/homeservice/26.jpg", null, 8, "سیم کشی و کابل کشی" },
                    { 27, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2487), "سرویس رفع اتصالی شامل شناسایی و تعمیر اتصالات برق معیوب، بررسی سیستم‌های برقی، تعویض فیوزها و سیم‌های آسیب‌دیده است. این سرویس برای جلوگیری از خطرات برقی و بهبود عملکرد سیستم برق‌رسانی ارائه می‌شود.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/27.jpg", null, 8, "رفع اتصالی" },
                    { 28, 150000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2491), "سرویس نصب و تعمیر آیفون شامل نصب سیستم‌های آیفون صوتی و تصویری، تعمیر و رفع مشکلات مربوط به صدا، تصویر، دکمه‌ها و اتصالات است. این سرویس برای بهبود عملکرد و افزایش امنیت ساختمان‌ها ارائه می‌شود.", "/assets/img/homeservice/28.jpg", null, 8, "نصب و تعمیر ایفون" },
                    { 29, 150000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2493), "سرویس نصب لوستر و چراغ شامل نصب انواع لوسترها و چراغ‌های تزئینی، تنظیم ارتفاع و بررسی اتصالات برقی است. این سرویس برای روشنایی و زیباسازی فضاهای داخلی منازل و ادارات ارائه می‌شود.", "/assets/img/homeservice/29.jpg", null, 8, "نصب لوستروچراغ" },
                    { 30, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2495), "سرویس نصب و تعمیر کلید و پریز شامل نصب انواع کلید و پریز برق، تعویض قطعات فرسوده، رفع اتصالات معیوب و بررسی ایمنی سیستم برق است. این سرویس برای بهبود عملکرد و ایمنی سیستم‌های برقی در ساختمان‌ها ارائه می‌شود.", "/assets/img/homeservice/30.jpg", null, 8, "کلید و پریز" },
                    { 31, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2497), "سرویس نصب و تعویض فیوز شامل بررسی سیستم برق‌رسانی، تعویض فیوزهای سوخته یا معیوب و تنظیم ایمنی مدارهای برقی است. این سرویس برای جلوگیری از بروز مشکلات برقی و حفظ امنیت ساختمان ارائه می‌شود.", "/assets/img/homeservice/31.jpg", null, 8, "نصب و تعویض فیوز" },
                    { 32, 400000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2500), "سرویس تعمیر و نگهداری آسانسور شامل بررسی و تعمیر سیستم‌های مکانیکی، الکتریکی و ایمنی آسانسور، تنظیم درب‌ها، روغن‌کاری قطعات و رفع مشکلات عملکردی است. این سرویس برای افزایش عمر مفید و بهبود عملکرد آسانسور ارائه می‌شود.", "/assets/img/homeservice/32.jpg", null, 8, "تعمیر و سرویس اسانسور" },
                    { 33, 100m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2502), "سرویس نصب سنسور تایمر شامل نصب سنسورهای حرکتی یا نور برای روشن و خاموش کردن اتوماتیک لوازم برقی مانند چراغ‌ها یا فن‌ها است. این سرویس به صرفه‌جویی در مصرف انرژی و افزایش راحتی در فضاهای مختلف کمک می‌کند.", "/assets/img/homeservice/33.jpg", null, 8, "نصب سنسور تایمر" },
                    { 34, 4000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2504), "سرویس ساخت کابینت و کمد دیواری شامل طراحی، ساخت و نصب انواع کابینت آشپزخانه، کمد دیواری و سیستم‌های ذخیره‌سازی سفارشی است. این سرویس برای بهینه‌سازی فضای داخلی و ایجاد دکوراسیون مرتب و کاربردی ارائه می‌شود.", "/assets/img/homeservice/34.jpg", null, 9, "ساخت کابینت وکمددیواری" },
                    { 35, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2505), "سرویس نجاری شامل ساخت، تعمیر و نصب انواع مبلمان چوبی، درب و پنجره، قفسه‌ها و سایر وسایل چوبی است. این سرویس برای ایجاد دکوراسیون چوبی زیبا و مقاوم در فضاهای مسکونی و اداری ارائه می‌شود.", "/assets/img/homeservice/35.jpg", null, 9, "نجاری" },
                    { 36, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2507), "سرویس تعمیرات مبلمان شامل تعمیر، بازسازی و نوسازی انواع مبلمان چوبی و پارچه‌ای، تعویض پارچه، فوم، و تعمیر اسکلت و پایه‌ها است. این سرویس به حفظ زیبایی و دوام مبلمان کمک می‌کند.", "/assets/img/homeservice/36.jpg", null, 9, "تعمیرات مبلمان" },
                    { 37, 2500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2611), "سرویس خدمات درب چوبی و ضد سرقت شامل نصب، تعمیر، تعویض یراق‌آلات، تنظیم درب‌ها، و بررسی ایمنی است. این سرویس برای افزایش امنیت و زیبایی درب‌های ورودی ساختمان‌ها ارائه می‌شود.", "/assets/img/homeservice/37.jpg", null, 9, "خدمات درب چوبی و ضد سرقت" },
                    { 38, 2500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2613), "سرویس نصب پارتیشن شیشه‌ای شامل طراحی، اندازه‌گیری، برش و نصب پارتیشن‌های شیشه‌ای برای تقسیم‌بندی فضاهای داخلی است. این سرویس برای ایجاد فضای جداگانه و زیبا با نوردهی مناسب در ادارات و محیط‌های تجاری ارائه می‌شود.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/38.jpg", null, 10, "پارتیشن شیشه ای" },
                    { 39, 1500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2615), "سرویس شیشه‌بری و آینه‌کاری شامل برش دقیق انواع شیشه‌ها و آینه‌ها، نصب و چسباندن آن‌ها در فضاهای مختلف مانند پنجره‌ها، درب‌ها، دیوارها و دکورهای داخلی است. این سرویس برای زیباسازی و تأمین نیازهای شیشه‌ای و آینه‌ای در ساختمان‌ها ارائه می‌شود.", "/assets/img/homeservice/39.jpg", null, 10, "شیشه بری و اینه کاری" },
                    { 40, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2617), "سرویس نصب شیشه ریلی اسلاید شامل طراحی، برش و نصب شیشه‌های ریلی متحرک برای فضاهایی مانند درب‌های ورودی، پارتیشن‌ها و فضاهای تجاری است. این سرویس برای استفاده بهینه از فضا و ایجاد ظاهری مدرن و شیک ارائه می‌شود.", "/assets/img/homeservice/40.jpg", null, 10, "شیشه ریلی اسلاید" },
                    { 41, 3000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2619), "سرویس تعمیر و نگهداری موتورخانه شامل بررسی و تعمیر سیستم‌های گرمایشی و سرمایشی مانند پکیج‌ها، بویلرها، پمپ‌ها و سیستم‌های لوله‌کشی است. این سرویس برای بهبود عملکرد، افزایش بهره‌وری و جلوگیری از مشکلات احتمالی در موتورخانه ارائه می‌شود.", "/assets/img/homeservice/41.jpg", null, 11, "تعمیرونگهداری موتور خانه" },
                    { 42, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2620), "سرویس و تعمیر چیلر شامل عیب‌یابی و تعمیر کمپرسور، تمیز کردن فیلترها، بررسی و تنظیم سیستم‌های گاز، شارژ گاز و عایق‌کاری لوله‌ها است. این سرویس برای بهبود عملکرد و افزایش طول عمر چیلرها در سیستم‌های تهویه مطبوع تجاری و صنعتی ارائه می‌شود.", "/assets/img/homeservice/42.jpg", null, 11, "سرویس و تعمیر چیلر" },
                    { 43, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2622), "سرویس نصب و تعمیر یخچال و فریزر شامل نصب دستگاه، عیب‌یابی، تعمیر کمپرسور، تعویض قطعات معیوب، شارژ گاز و تنظیم دما است. این سرویس برای بهبود عملکرد و طول عمر یخچال و فریزر در منازل و محیط‌های تجاری ارائه می‌شود.", "/assets/img/homeservice/43.jpg", null, 11, "نصب و تعمیر یخچال وفریز" },
                    { 44, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2624), "سرویس نصب و تعمیر ماشین لباسشویی شامل نصب دستگاه، بررسی و رفع مشکلات مربوط به موتور، پمپ آب، برد الکترونیکی، تعویض قطعات معیوب و تعمیر نشت آب است. این سرویس برای بهبود عملکرد و طول عمر ماشین لباسشویی در خانه‌ها و محیط‌های تجاری ارائه می‌شود.", "/assets/img/homeservice/44.jpg", null, 11, "نصب و تعمیر ماشین لباسشویی" },
                    { 45, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2626), "سرویس نصب و تعمیر ماشین ظرفشویی شامل نصب دستگاه، عیب‌یابی و تعمیر مشکلات مربوط به موتور، پمپ آب، فیلترها، برد الکترونیکی و رفع نشت آب است. این سرویس برای بهبود عملکرد و افزایش عمر مفید ماشین ظرفشویی در منازل و محیط‌های تجاری ارائه می‌شود.", "/assets/img/homeservice/45.jpg", null, 11, "نصب و تعمیرماشین ظرفشویی" },
                    { 46, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2627), "سرویس تعمیر جاروبرقی شامل عیب‌یابی و تعمیر موتور، تعویض قطعات معیوب مانند فیلتر، لوله و برس‌ها، رفع مشکلات مکش و بررسی سیم برق است. این سرویس برای بهبود عملکرد و افزایش عمر مفید جاروبرقی در منازل و محیط‌های تجاری ارائه می‌شود.", "/assets/img/homeservice/46.jpg", null, 11, "تعمیر جاروبرقی" },
                    { 47, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2629), "سرویس تعمیر کامپیوتر و لپ‌تاپ شامل عیب‌یابی و تعمیر مشکلات سخت‌افزاری و نرم‌افزاری، تعویض قطعات معیوب، نصب سیستم‌عامل، به‌روزرسانی نرم‌افزارها و رفع مشکلات مربوط به عملکرد سیستم است. این سرویس برای بهبود عملکرد و افزایش طول عمر دستگاه‌ها ارائه می‌شود.", "/assets/img/homeservice/47.jpg", null, 12, "تعمیر کامپیوتر و لپ تاپ" },
                    { 48, 1500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2631), "سرویس تعمیر ماشین‌های اداری شامل تعمیر و نگهداری دستگاه‌هایی مانند پرینتر، اسکنر، فکس و کپی است. این سرویس شامل عیب‌یابی، تعویض قطعات معیوب، تعمیر مکانیزم‌های داخلی و به‌روزرسانی نرم‌افزارها برای بهبود عملکرد دستگاه‌ها ارائه می‌شود.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/48.jpg", null, 12, "تعمیر ماشین های اداری" },
                    { 49, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2633), "سرویس نصب و تعمیر مودم و اینترنت شامل راه‌اندازی مودم، تنظیمات شبکه، بررسی سرعت اینترنت، رفع مشکلات اتصال و عیب‌یابی کابل‌ها و اتصالات است. این سرویس برای بهبود عملکرد اینترنت و رفع مشکلات شبکه در منازل و محیط‌های تجاری ارائه می‌شود.", "/assets/img/homeservice/49.jpg", null, 12, "مودم واینترنت" },
                    { 50, 1500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2635), "سرویس خدمات تاچ و ال سی دی شامل تعمیر یا تعویض صفحه نمایش لمسی و ال سی دی در دستگاه‌هایی مانند گوشی‌های موبایل، تبلت‌ها و لپ‌تاپ‌ها است. این سرویس برای رفع مشکلات صفحه نمایش، از جمله ترک‌خوردگی، رنگ‌پریدگی یا نواقص لمسی ارائه می‌شود.", "/assets/img/homeservice/50.jpg", null, 13, "خدمات تاچ و ال سی دی" },
                    { 51, 300000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2647), "سرویس خدمات باتری موبایل شامل تعویض باتری معیوب، بررسی عملکرد باتری، کالیبراسیون و رفع مشکلات شارژ در دستگاه‌های موبایل است. این سرویس برای بهبود عمر باتری و عملکرد دستگاه‌های موبایل ارائه می‌شود.", "/assets/img/homeservice/51.jpg", null, 13, " خدمات باتری موبایل" },
                    { 52, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2649), "سرویس خدمات نرم‌افزاری شامل نصب، به‌روزرسانی، پشتیبانی و رفع مشکلات نرم‌افزاری در سیستم‌های مختلف، از جمله نصب سیستم‌عامل، برنامه‌ها و ابزارهای کاربردی است. این سرویس برای بهبود عملکرد و رفع اشکالات نرم‌افزاری در دستگاه‌های مختلف ارائه می‌شود.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/52.jpg", null, 13, "خدمات نرم افزاری" },
                    { 53, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2651), "سرویس اسباب‌کشی با خاور و کامیون شامل حمل و نقل اثاثیه منزل یا اداری با استفاده از وسایل نقلیه بزرگ و مناسب، بسته‌بندی ایمن، بارگیری، تخلیه و انتقال به مقصد است. این سرویس برای راحتی و امنیت در جابجایی اثاثیه ارائه می‌شود.", "/assets/img/homeservice/53.jpg", null, 14, " اسباب کشی با خاور و کامیون" },
                    { 54, 1500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2654), "سرویس اسباب‌کشی با وانت و نیسان شامل حمل و نقل اثاثیه کوچک و متوسط با استفاده از خودروهای مناسب برای جابجایی سریع و ایمن است. این سرویس برای انتقال اثاثیه از منزل یا دفتر به مقصد با هزینه مناسب و سرعت بالا ارائه می‌شود.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/54.jpg", null, 14, "اسباب کشی با وانت و نیسان" },
                    { 55, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2656), "سرویس بسته‌بندی شامل بسته‌بندی ایمن و مطمئن اثاثیه و کالاها با استفاده از مواد محافظ مانند فوم، کارتن، نوار چسب و پلاستیک حبابدار است. این سرویس برای جلوگیری از آسیب‌دیدگی در حین حمل‌ونقل و جابجایی اثاثیه ارائه می‌شود.", "/assets/img/homeservice/55.jpg", null, 14, "سرویس بسته بندی" },
                    { 56, 300000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2657), "سرویس اسباب‌کشی شرکت‌ها و سازمان‌ها شامل جابجایی اثاثیه اداری، مبلمان، تجهیزات کامپیوتری و اسناد با استفاده از وسایل نقلیه مناسب و بسته‌بندی ایمن است. این سرویس برای انتقال راحت و بدون دردسر شرکت‌ها و سازمان‌ها به محل جدید ارائه می‌شود.", "/assets/img/homeservice/56.jpg", null, 14, "اسباب کشی شرکت ها و سازمان ها" },
                    { 57, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2660), "سرویس تعویض باتری خودرو شامل بررسی وضعیت باتری، تعویض باتری فرسوده با باتری جدید و انجام تست‌های لازم برای اطمینان از عملکرد صحیح سیستم برق‌رسانی خودرو است. این سرویس برای حفظ عملکرد بهینه خودرو و جلوگیری از مشکلات ناشی از خرابی باتری ارائه می‌شود.", "/assets/img/homeservice/57.jpg", null, 15, "تعویض باتری خودرو" },
                    { 58, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2661), "سرویس باتری به باتری شامل کمک به خودروهایی است که باتری آن‌ها خالی یا خراب شده است. در این سرویس، باتری سالم از یک خودرو به خودرو دیگر منتقل می‌شود تا آن را روشن کرده و مشکل باتری خودرو رفع شود. این سرویس در مواقع اضطراری برای شروع حرکت خودرو ارائه می‌شود.", "/assets/img/homeservice/58.jpg", null, 15, "باتری ب باتری" },
                    { 59, 3000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2663), "سرویس مکانیکی خودرو شامل تعمیرات و نگهداری سیستم‌های مختلف خودرو، از جمله موتور، ترمزها، سیستم تعلیق، اگزوز، و انتقال نیرو است. این سرویس برای رفع مشکلات فنی و بهبود عملکرد خودرو ارائه می‌شود.", "/assets/img/homeservice/59.jpg", null, 15, "مکانیکی خودرو" },
                    { 60, 2500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2665), "سرویس کارشناسی خودرو شامل بررسی دقیق وضعیت فنی و ظاهری خودرو قبل از خرید یا فروش، از جمله بررسی موتور، سیستم ترمز، بدنه، شاسی، سیستم تعلیق، و تشخیص مشکلات مخفی است. این سرویس برای اطمینان از سلامت خودرو و جلوگیری از خرید یا فروش خودرو با مشکلات پنهان ارائه می‌شود.", "/assets/img/homeservice/60.jpg", null, 15, "کارشناسی خودرو" },
                    { 61, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2667), "سرویس تعویض لاستیک شامل جابجایی لاستیک‌های فرسوده یا آسیب‌دیده با لاستیک‌های جدید، بررسی وضعیت تایرها، و تنظیم فشار باد لاستیک‌ها است. این سرویس برای حفظ ایمنی و بهبود عملکرد خودرو در جاده‌ها ارائه می‌شود.", "/assets/img/homeservice/61.jpg", null, 15, "تعویض لاستیک" },
                    { 62, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2668), "سرویس تعویض لنت شامل بررسی وضعیت لنت‌های ترمز، تعویض لنت‌های فرسوده با لنت‌های جدید، و تنظیم سیستم ترمز برای بهبود عملکرد آن است. این سرویس برای افزایش ایمنی خودرو و بهبود عملکرد ترمزها ارائه می‌شود.", "/assets/img/homeservice/62.jpg", null, 15, "تعویض لنت" },
                    { 63, 600000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2670), "سرویس تعویض روغن شامل تخلیه روغن قدیمی موتور، تعویض فیلتر روغن و افزودن روغن جدید به موتور است. این سرویس برای حفظ عملکرد بهینه موتور، کاهش سایش و افزایش طول عمر آن ارائه می‌شود.", "/assets/img/homeservice/63.jpg", null, 15, "تعویض روغن" },
                    { 64, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2672), "سرویس دوره‌ای گیربکس اتوماتیک شامل بررسی و تعویض روغن گیربکس، تنظیم و بازبینی سیستم انتقال قدرت، و اطمینان از عملکرد صحیح قطعات داخلی گیربکس است. این سرویس برای حفظ عملکرد بهینه گیربکس، جلوگیری از مشکلات فنی و افزایش طول عمر سیستم انتقال قدرت خودرو ارائه می‌شود.", "/assets/img/homeservice/64.jpg", null, 15, "سرویس دوره ای گیربکس اتوماتیک" },
                    { 65, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2674), "سرویس سرامیک خودرو شامل اعمال پوشش نانو سرامیک بر روی بدنه خودرو است که به منظور حفاظت از رنگ و سطح خودرو در برابر خراش‌ها، لکه‌ها، آلودگی‌ها و اشعه UV انجام می‌شود. این پوشش باعث براقیت بیشتر، دوام بیشتر و سهولت در تمیز کردن سطح خودرو می‌شود.", "/assets/img/homeservice/65.jpg", null, 16, "سرامیک خودرو" },
                    { 66, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2686), "سرویس کارواش نانو شامل شستشوی خودرو با استفاده از محصولات نانو تکنولوژی است که به طور مؤثری آلودگی‌ها، گرد و غبار، و لکه‌ها را از بین می‌برد. این روش شستشو به سطح خودرو لایه‌ای محافظتی می‌دهد که باعث حفظ براقیت رنگ و جلوگیری از ایجاد لکه‌های جدید می‌شود.", "/assets/img/homeservice/66.jpg", null, 16, "کارواش نانو" },
                    { 67, 700000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2688), "سرویس کارواش با آب شامل شستشوی خودرو با استفاده از آب و مواد شوینده مخصوص است که به طور مؤثر خاک، کثیفی و لکه‌ها را از بدنه، چرخ‌ها و شیشه‌ها پاک می‌کند. این روش شستشو برای تمیز کردن کامل خودرو و حفظ ظاهر آن در شرایط عادی ارائه می‌شود.", "/assets/img/homeservice/67.jpg", null, 16, "کارواش با اب" },
                    { 68, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2690), "سرویس موتورشویی خودرو شامل تمیز کردن و شستشوی موتور خودرو با استفاده از مواد شوینده مخصوص است. این سرویس به پاک‌سازی روغن، کثیفی و گرد و غبار از بخش‌های مختلف موتور کمک کرده و باعث بهبود عملکرد و جلوگیری از آسیب به قطعات می‌شود.", "/assets/img/homeservice/68.jpg", null, 16, "موتورشویی خودرو" },
                    { 69, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2692), "سرویس نصب شیشه دودی در محل شامل نصب فیلترهای دودی بر روی شیشه‌های خودرو یا ساختمان است. این سرویس به منظور کاهش تابش نور خورشید، حفظ حریم خصوصی، و جلوگیری از افزایش دمای داخل خودرو یا فضا ارائه می‌شود. شیشه دودی همچنین به محافظت از مواد داخلی در برابر اشعه UV کمک می‌کند.", "/assets/img/homeservice/69.jpg", null, 16, "نصب شیشه دودی درمحل" },
                    { 70, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2694), "سرویس خدمات ناخن شامل انجام انواع خدمات مراقبت و زیبایی ناخن‌ها از جمله مانیکور، پدیکور، کاشت ناخن، ترمیم ناخن، طراحی و لاک زدن است. این سرویس برای تقویت، بهبود ظاهر و زیباسازی ناخن‌ها ارائه می‌شود.", "/assets/img/homeservice/70.jpg", null, 17, "خدمات ناخن" },
                    { 71, 600000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2695), "سرویس رنگ مو بانوان شامل انتخاب و اعمال رنگ مو بر اساس سلیقه مشتری، از جمله رنگ‌های طبیعی یا فانتزی، با استفاده از رنگ‌های حرفه‌ای و ماندگار است. این سرویس برای تغییر رنگ، پوشاندن موهای سفید یا ایجاد جلوه‌ای جدید و زیبا بر روی موهای بانوان ارائه می‌شود.", "/assets/img/homeservice/71.jpg", null, 17, "رنگ مو بانوان" },
                    { 72, 700000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2697), "سرویس کوتاهی مو بانوان شامل اصلاح و کوتاه کردن موها با توجه به سلیقه مشتری و مدل‌های روز است. این سرویس برای ایجاد تغییرات ظاهری، رفع موهای آسیب‌دیده و فرم‌دهی به موها برای ظاهر مرتب و شیک ارائه می‌شود.", "/assets/img/homeservice/72.jpg", null, 17, "کوتاهی مو بانوان" },
                    { 73, 100000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2699), "سرویس کراتینه و ویتامینه مو بانوان شامل درمان و بازسازی موهای آسیب‌دیده با استفاده از مواد کراتینه و ویتامین‌های مغذی است. این سرویس باعث نرمی، درخشندگی و سلامت موها می‌شود و همچنین به کاهش وز و آسیب‌های ناشی از استفاده زیاد از ابزارهای حرارتی کمک می‌کند.", "/assets/img/homeservice/73.jpg", null, 17, "کراتینه و ویتامینه مو بانوان" },
                    { 74, 800000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2701), "سرویس بافت مو بانوان شامل انواع مدل‌های بافت مو مانند بافت ساده، فانتزی، فرانسوی یا آفریقایی است که به موها ظاهری خاص و زیبا می‌دهد. این سرویس برای ایجاد مدل‌های متفاوت و جذاب برای مناسبت‌ها یا استفاده روزانه ارائه می‌شود.", "/assets/img/homeservice/74.jpg", null, 17, "بافت مو بانوان" },
                    { 75, 800000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2702), "سرویس مراقبت و نگهداری از سالمندان، کودکان و بیماران شامل ارائه خدمات بهداشتی، مراقبتی و رفاهی به افراد نیازمند مراقبت است. این سرویس ممکن است شامل کمک در انجام فعالیت‌های روزمره، نظافت، مصرف داروها، همراهی در مراجعه به پزشک، و فراهم کردن محیطی امن و راحت برای این افراد باشد.", "/assets/img/homeservice/75.jpg", null, 18, "مراقلت و نگهداری" },
                    { 76, 800000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2704), "سرویس پرستاری و تزریقات شامل ارائه خدمات بهداشتی و پزشکی در منزل است که شامل تزریق داروها، خون‌گیری، پانسمان، و سایر خدمات مراقبتی و پرستاری می‌شود. این سرویس برای افرادی که نیاز به مراقبت‌های پزشکی مداوم دارند یا نمی‌توانند به مراکز درمانی مراجعه کنند، ارائه می‌شود.", "/assets/img/homeservice/76.jpg", null, 18, "پرستاری و تزریقات" },
                    { 77, 500000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2706), "سرویس معاینه پزشکی شامل ارزیابی و بررسی سلامت عمومی فرد توسط پزشک است. این معاینه می‌تواند شامل بررسی علائم بیماری، آزمایشات فیزیکی، مشاوره درباره سبک زندگی و تجویز درمان‌های مورد نیاز باشد. هدف این سرویس پیشگیری از بیماری‌ها و تشخیص زودهنگام مشکلات بهداشتی است.", "/assets/img/homeservice/77.jpg", null, 18, "معاینه پزشکی" },
                    { 78, 400000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2708), "سرویس خدمات دامپزشکی در محل شامل ارائه مراقبت‌های پزشکی و درمانی برای حیوانات خانگی یا دام‌ها در محل زندگی یا مزرعه است. این خدمات می‌تواند شامل معاینه، درمان بیماری‌ها، واکسیناسیون، دارودرمانی و جراحی‌های جزئی باشد. هدف این سرویس فراهم آوردن راحتی برای صاحب حیوانات و ارائه خدمات بهداشتی بدون نیاز به مراجعه به کلینیک دامپزشکی است.", "/assets/img/homeservice/78.jpg", null, 19, "خدمات دامپزشکی در محل" },
                    { 79, 300000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2709), "سرویس خدمات تربیت حیوانات خانگی شامل آموزش و تربیت حیوانات مانند سگ‌ها و گربه‌ها برای رفتارهای خاص یا رفع مشکلات رفتاری است. این خدمات ممکن است شامل آموزش فرمان‌های ساده، اصلاح رفتارهای نامطلوب، اجتماعی‌سازی حیوان و ایجاد عادات مناسب برای تعامل با انسان‌ها و سایر حیوانات باشد. هدف این سرویس، بهبود ارتباط صاحب حیوان با حیوان خانگی و فراهم آوردن محیطی سالم و هماهنگ است.", "/assets/img/homeservice/79.jpg", null, 19, "خدمات تربیت حیوانات خانگی" },
                    { 80, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2711), "سرویس شستشو و آرایش حیوانات خانگی شامل تمیز کردن، شستشو، و مرتب‌سازی موهای حیوانات خانگی است. این خدمات ممکن است شامل حمام، شستشوی مو، کوتاهی و اصلاح مو، شانه کردن، و استفاده از محصولات بهداشتی مخصوص حیوانات باشد. هدف این سرویس، بهبود بهداشت و ظاهر حیوانات خانگی و فراهم آوردن راحتی و سلامت برای آنها است.", "/assets/img/homeservice/80.jpg", null, 19, "خدمات شست وشو ارایشی حیوانات خانگی" },
                    { 81, 300000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2713), "سرویس مشاور مالی و مالیاتی شامل ارائه مشاوره تخصصی در زمینه مدیریت مالی، برنامه‌ریزی مالی، و مسائل مالیاتی است. این خدمات می‌تواند شامل کمک به تنظیم مالیات، کاهش هزینه‌ها، بهینه‌سازی سرمایه‌گذاری‌ها و برنامه‌ریزی برای آینده مالی باشد. مشاوران مالی و مالیاتی به افراد و کسب‌وکارها کمک می‌کنند تا تصمیمات مالی بهینه و مطابق با قوانین مالیاتی اتخاذ کنند.\n\n\n\n\n\n\n\n", "/assets/img/homeservice/81.jpg", null, 20, "مشاورمالی و مالیاتی" },
                    { 82, 200000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2715), "سرویس کوتاهی موی سر و اصلاح صورت مردانه شامل اصلاح و کوتاه کردن موهای سر به مدل‌های متنوع و مطابق با سلیقه مشتری، و همچنین اصلاح صورت با استفاده از تیغ، ماشین ریش‌زنی و سایر ابزارهای حرفه‌ای است. این سرویس برای ایجاد ظاهری مرتب، شیک و جذاب برای مردان طراحی شده و می‌تواند شامل اصلاح ریش، سبیل و طراحی خط‌های صورت باشد.", "/assets/img/homeservice/82jpg", null, 21, "کوتاهی موی سر و اصلاح صورت" },
                    { 83, 400000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2716), "سرویس گریم داماد شامل آرایش و زیباسازی چهره داماد برای روز عروسی است. این سرویس شامل استفاده از محصولات آرایشی مخصوص برای بهبود پوست، پوشاندن عیوب صورت، ایجاد جلوه‌ای طبیعی و زیبا، و تنظیم جزئیات چهره برای عکاسی و فیلمبرداری است. هدف این سرویس کمک به داماد برای داشتن ظاهری مرتب، جذاب و اعتماد به نفس بالا در روز مهم زندگی‌اش است.", "/assets/img/homeservice/83.jpg", null, 21, "گریم داماد" },
                    { 84, 1000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2718), "سرویس برنامه ورزشی و تغذیه شامل ارائه برنامه‌های تمرینی و رژیم‌های غذایی متناسب با اهداف فردی مانند کاهش وزن، افزایش عضله، بهبود سلامت عمومی یا افزایش استقامت است. این برنامه‌ها بر اساس وضعیت بدنی، نیازها و سبک زندگی فرد طراحی می‌شود و ممکن است شامل تمرینات قدرتی، هوازی، انعطاف‌پذیری و تغذیه سالم با توجه به نیازهای تغذیه‌ای خاص هر شخص باشد. هدف این سرویس کمک به فرد برای رسیدن به اهداف ورزشی و بدنی خود به صورت مؤثر و سالم است.", "/assets/img/homeservice/84.jpg", null, 22, "برنامه ورزشی و تغذیه" },
                    { 85, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2720), "سرویس کلاس یوگا در خانه شامل برگزاری جلسات یوگا با مربی مجرب در منزل شما است. این کلاس‌ها می‌تواند شامل تمرینات تنفسی، انعطاف‌پذیری، تقویت عضلات، و مدیتیشن باشد و به بهبود سلامت جسمی و روانی کمک کند. کلاس‌های یوگا در خانه برای افرادی که وقت یا تمایل به رفتن به باشگاه ندارند، گزینه‌ای راحت و شخصی است.", "/assets/img/homeservice/85.jpg", null, 22, "کلاس یوگا در خانه" },
                    { 86, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2722), "سرویس کلاس فیتنس در خانه شامل برگزاری جلسات تمرینی شخصی یا گروهی در منزل شما است. این کلاس‌ها ممکن است شامل تمرینات هوازی، قدرتی، HIIT، کار با وزنه یا تمرینات متناسب با اهداف خاص شما مانند کاهش وزن، افزایش قدرت یا بهبود تناسب اندام باشد. این سرویس به افراد این امکان را می‌دهد که بدون نیاز به مراجعه به باشگاه، تمرینات خود را در خانه انجام دهند و از راهنمایی و حمایت مربی بهره‌مند شوند.", "/assets/img/homeservice/86.jpg", null, 22, "کلاس فیتنس در خانه" },
                    { 87, 5000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2723), "با استفاده از خدمات تخصصی آچار، تجهیزات و زیرساخت‌های فنی شرکت خود را همیشه در بهترین شرایط نگه دارید. ما با ارائه تعمیرات، سرویس‌های دوره‌ای، تأمین قطعات و پشتیبانی فنی، به شما کمک می‌کنیم تا هزینه‌های نگهداری را کاهش داده، بهره‌وری را افزایش دهید و از خرابی‌های ناگهانی جلوگیری کنید.", "/assets/img/homeservice/87.jpg", null, 23, "پیشنهادفروش خدمات آچار ب شرکت ها" },
                    { 88, 8000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2725), "آچار با ارائه خدمات تخصصی برای شرکت‌های بزرگ، بهره‌وری را افزایش داده و هزینه‌های عملیاتی را کاهش می‌دهد. این خدمات شامل نگهداری پیشگیرانه برای جلوگیری از خرابی‌های ناگهانی، پشتیبانی ۲۴/۷ برای رفع سریع مشکلات، تأمین قطعات یدکی با تضمین کیفیت، بهینه‌سازی و ارتقای تجهیزات برای بهبود عملکرد و کاهش مصرف انرژی، و همچنین ارائه راهکارهای اختصاصی متناسب با نیازهای هر سازمان است.", "/assets/img/homeservice/88.jpg", null, 23, "خدمات شرکت ویژه شرکت های بزرگ" },
                    { 89, 3000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2727), "سرویس استخدام بادیگارد خدمات حفاظت شخصی، امنیتی و تشریفاتی را با تیمی از افراد حرفه‌ای، آموزش‌دیده و مجهز ارائه می‌دهد تا امنیت افراد، مدیران، سلبریتی‌ها و رویدادهای خاص تضمین شود.", "/assets/img/homeservice/89.jpg", null, 24, "استخدام بادیگارد" },
                    { 90, 2000000m, new DateTime(2025, 2, 13, 19, 39, 18, 603, DateTimeKind.Local).AddTicks(2728), "سرویس استخدام راننده ارائه‌دهنده رانندگان حرفه‌ای، با‌تجربه و قابل‌اعتماد برای جابه‌جایی ایمن و راحت مدیران، افراد مهم و سازمان‌ها با خودروهای شخصی یا تشریفاتی است.", "/assets/img/homeservice/90.jpg", null, 24, "استخدام راننده" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ApplicationUserId",
                table: "Admins",
                column: "ApplicationUserId",
                unique: true);

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ExpertId",
                table: "Bids",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_RequestId",
                table: "Bids",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CustomerId",
                table: "Comments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ExpertId",
                table: "Comments",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ApplicationUserId",
                table: "Customers",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CityId",
                table: "Customers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Experts_ApplicationUserId",
                table: "Experts",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experts_CityId",
                table: "Experts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpertSubCategory_SkillsId",
                table: "ExpertSubCategory",
                column: "SkillsId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeServices_SubCategoryId",
                table: "HomeServices",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_AcceptedExpertId",
                table: "Requests",
                column: "AcceptedExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CustomerId",
                table: "Requests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

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
                name: "Bids");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ExpertSubCategory");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DropTable(
                name: "HomeServices");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
