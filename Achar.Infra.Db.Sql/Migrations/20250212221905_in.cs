using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Achar.Infra.Db.SqLServer.Migrations
{
    /// <inheritdoc />
    public partial class @in : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Experts_ExpertId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Requests_RequestId",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "Proposal");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_RequestId",
                table: "Proposal",
                newName: "IX_Proposal_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_ExpertId",
                table: "Proposal",
                newName: "IX_Proposal_ExpertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proposal",
                table: "Proposal",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 101, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f68436bb-c6c5-4ad2-90ec-87e0a5c4f7aa", "AQAAAAIAAYagAAAAEOiYs/luJhvB+BfkB7lWZmzGexx4JN2djtvFVE/mc2/fMgOEeS6Q0waXTG/vWDrteQ==", "8b108470-e68b-4fd7-91a1-9afcc07073cc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a830fa1c-f921-4806-a9d2-5b10f7259c0e", "AQAAAAIAAYagAAAAECOj15J4KUwpGyR4mgG5ccj07Mq0qNx3Wq9NHxtV8qifCH1Nf3TrN/VJK0umc0QDNg==", "282ad640-1f24-4852-af3d-7820c7bb49d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21ce23ae-b6d9-4de8-b8d8-36cbe2e17a86", "AQAAAAIAAYagAAAAENmvW6v44A98M7BU23f9g7HJeAqPDmOI3gVhUQZjI9rI295gNO28c30pyTQy/OdCJQ==", "8a379dea-749c-4449-b596-896ec49bfb33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3208af30-38c2-462d-98e9-5f68f90b016a", "AQAAAAIAAYagAAAAEOJHZ1UUi7PrCUOlE2I0anXpTks+GTqu61+pkAO/Cg3VOTJDZ4uCKP1Y13IEFExo5Q==", "a262052c-dd72-48be-ad97-ee86e4659007" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5a1c37a-f90b-4aea-b57f-ee438e602685", "AQAAAAIAAYagAAAAEGyJKwAC65po+dssjs5afOnQqA0ftmRwDu4gQHbsgfRWE+sXLNWBlg/2+zygL0UBFQ==", "67eff4ec-5654-41f0-8d6a-cd332bfcffbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f0710a-a6b9-424c-a966-85afcd1233ba", "AQAAAAIAAYagAAAAEIU3LULVVeW5R1uvyvZhXQ1qTiYsfcjYq70yasgLSZSH5XlPZ/cmZ5unZydCjapXAg==", "41a674aa-e54f-47cc-ba42-faa4225defce" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7635));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7637));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7640));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 106, DateTimeKind.Local).AddTicks(7643));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4107));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4114));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4115));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4117));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4119));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4122));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4124));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4126));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4131));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4135));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 110, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 113, DateTimeKind.Local).AddTicks(9124));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 113, DateTimeKind.Local).AddTicks(9963));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 113, DateTimeKind.Local).AddTicks(9966));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 115, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 115, DateTimeKind.Local).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(3239));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4294));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4302));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4306));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4308));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4312));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4318));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4362));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4375));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4392));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4398));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4402));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4404));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4405));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4407));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4409));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4416));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4428));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4430));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4432));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4436));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4440));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4443));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4445));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4467));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4472));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4549));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4551));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4553));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4557));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4559));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4560));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4562));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4579));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4581));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4584));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4586));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4590));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4594));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4597));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 121, DateTimeKind.Local).AddTicks(4612));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8547));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8552));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8553));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8558));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8559));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8565));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8572));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8574));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 49, 4, 125, DateTimeKind.Local).AddTicks(8578));

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Experts_ExpertId",
                table: "Proposal",
                column: "ExpertId",
                principalTable: "Experts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Requests_RequestId",
                table: "Proposal",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Experts_ExpertId",
                table: "Proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Requests_RequestId",
                table: "Proposal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proposal",
                table: "Proposal");

            migrationBuilder.RenameTable(
                name: "Proposal",
                newName: "Bids");

            migrationBuilder.RenameIndex(
                name: "IX_Proposal_RequestId",
                table: "Bids",
                newName: "IX_Bids_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_Proposal_ExpertId",
                table: "Bids",
                newName: "IX_Bids_ExpertId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 75, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd433bb7-80aa-46b5-b748-7840a773f6ea", "AQAAAAIAAYagAAAAECg8GlAIjYJnH4xkm5KE0OOiWlu7wrNzWpn0GTTywzP9tAzVe0/m5ajcik1wYDZNhQ==", "856fdef9-2951-44ca-a10a-0b198c6339ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41469b00-b45e-4bc1-83de-9f1f05f05e23", "AQAAAAIAAYagAAAAELEgg7isrx+ZhXoZ2NqrdRdURlLPz1cO9mN1nnsBKxTDkric3wO/DruoL1YI6tdZ1A==", "33d934ec-1bd8-410a-b7f8-87817c6e57c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f696462-4dd2-4528-aec7-64a5fd2d6dd9", "AQAAAAIAAYagAAAAEF8J//T7JkJSYEhIbLxgMZQoRkDNBsI7vHUVdwicdyr/YlK5wIU99wDwxWgQ0K7jHg==", "91b37918-37d8-4324-bfe3-6e5c9823436b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91412e55-e6bc-480a-ae81-648706db10b8", "AQAAAAIAAYagAAAAEEjEL6NZMhmYDuzpnLjLqCmPSUSKyPwgsnT2H0Hxu4PNS/+4EuH4VDa5PJoqS3E/cA==", "a58bc4e8-e8c0-42ec-9ca2-179ec6b0931c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ecc917c-15a5-47ef-a2f4-bdd53852da74", "AQAAAAIAAYagAAAAEGs4atAU8HdnvBB+oxj+gcmBNX4BAqzKb7CLXHB3UXKMXNvU0CxOB93LVpOLBftGOw==", "e7e59911-d315-49c9-8e87-aee33735fd05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "510a4174-b50b-4f9e-bc63-091395dc5911", "AQAAAAIAAYagAAAAEE+Rq2mriA7f6bLxMblAVv1GN7Bmd0Ygn4b5xGxUDKiFEGbi3vl0vxhTtRhJJBlXEQ==", "4514a8c9-b13a-4beb-ae42-1591c6c99275" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9072));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9750));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9752));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 80, DateTimeKind.Local).AddTicks(9757));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2384));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2387));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2394));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2397));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2398));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2403));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2405));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 85, DateTimeKind.Local).AddTicks(2415));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 88, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 88, DateTimeKind.Local).AddTicks(9016));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 88, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 90, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Experts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 90, DateTimeKind.Local).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 97, DateTimeKind.Local).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(350));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(355));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(357));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(359));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(362));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(389));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(393));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(395));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(402));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(404));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(406));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(410));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(412));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(414));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(430));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(434));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(436));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(438));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(442));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(444));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(446));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(448));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(452));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(469));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(471));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(516));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(520));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(524));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(526));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(532));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(534));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(536));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(558));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(560));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(562));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(565));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(566));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(568));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 60,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 61,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 62,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 63,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 64,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 65,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 66,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 67,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(596));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 68,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 69,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 70,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 71,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 72,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 73,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 74,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 75,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 76,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 77,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 78,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(617));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 79,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(619));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 80,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(622));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 81,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(623));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 82,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(625));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 83,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 84,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 85,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 86,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(633));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 87,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(635));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 88,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(637));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 89,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "HomeServices",
                keyColumn: "Id",
                keyValue: 90,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 98, DateTimeKind.Local).AddTicks(641));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8374));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8422));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8426));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8427));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8430));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8432));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8433));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8436));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8438));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8440));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8441));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8443));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreateAt",
                value: new DateTime(2025, 2, 13, 1, 45, 26, 102, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Experts_ExpertId",
                table: "Bids",
                column: "ExpertId",
                principalTable: "Experts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Requests_RequestId",
                table: "Bids",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
