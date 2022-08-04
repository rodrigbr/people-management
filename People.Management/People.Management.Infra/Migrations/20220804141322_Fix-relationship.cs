using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace People.Management.Infra.Migrations
{
    public partial class Fixrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Schooling_SchoolingId",
                schema: "u",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_SchoolRecord_SchoolRecordId",
                schema: "u",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolingId",
                schema: "u",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolRecordId",
                schema: "u",
                table: "User",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Schooling_User_Id",
                schema: "u",
                table: "Schooling",
                column: "Id",
                principalSchema: "u",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolRecord_User_Id",
                schema: "u",
                table: "SchoolRecord",
                column: "Id",
                principalSchema: "u",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Schooling_SchoolingId",
                schema: "u",
                table: "User",
                column: "SchoolingId",
                principalSchema: "u",
                principalTable: "Schooling",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_SchoolRecord_SchoolRecordId",
                schema: "u",
                table: "User",
                column: "SchoolRecordId",
                principalSchema: "u",
                principalTable: "SchoolRecord",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schooling_User_Id",
                schema: "u",
                table: "Schooling");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolRecord_User_Id",
                schema: "u",
                table: "SchoolRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Schooling_SchoolingId",
                schema: "u",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_SchoolRecord_SchoolRecordId",
                schema: "u",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolingId",
                schema: "u",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SchoolRecordId",
                schema: "u",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Schooling_SchoolingId",
                schema: "u",
                table: "User",
                column: "SchoolingId",
                principalSchema: "u",
                principalTable: "Schooling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_SchoolRecord_SchoolRecordId",
                schema: "u",
                table: "User",
                column: "SchoolRecordId",
                principalSchema: "u",
                principalTable: "SchoolRecord",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
