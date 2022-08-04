using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace People.Management.Infra.Migrations
{
    public partial class RefactorUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_ReferenceId",
                schema: "u",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_SchoolRecord_ReferenceId",
                schema: "u",
                table: "SchoolRecord");

            migrationBuilder.DropIndex(
                name: "IX_Schooling_ReferenceId",
                schema: "u",
                table: "Schooling");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                schema: "u",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                schema: "u",
                table: "SchoolRecord");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "u",
                table: "Schooling");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                schema: "u",
                table: "Schooling");

            migrationBuilder.AddColumn<Guid>(
                name: "SchoolingId",
                schema: "u",
                table: "Schooling",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Schooling_SchoolingId",
                schema: "u",
                table: "Schooling",
                column: "SchoolingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schooling_ScholingType_SchoolingId",
                schema: "u",
                table: "Schooling",
                column: "SchoolingId",
                principalSchema: "u",
                principalTable: "ScholingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schooling_ScholingType_SchoolingId",
                schema: "u",
                table: "Schooling");

            migrationBuilder.DropIndex(
                name: "IX_Schooling_SchoolingId",
                schema: "u",
                table: "Schooling");

            migrationBuilder.DropColumn(
                name: "SchoolingId",
                schema: "u",
                table: "Schooling");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                schema: "u",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                schema: "u",
                table: "SchoolRecord",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "u",
                table: "Schooling",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                schema: "u",
                table: "Schooling",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_ReferenceId",
                schema: "u",
                table: "User",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRecord_ReferenceId",
                schema: "u",
                table: "SchoolRecord",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schooling_ReferenceId",
                schema: "u",
                table: "Schooling",
                column: "ReferenceId",
                unique: true);
        }
    }
}
