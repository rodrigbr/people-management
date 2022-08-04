using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace People.Management.Infra.Migrations
{
    public partial class Initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "u");

            migrationBuilder.CreateTable(
                name: "ScholingType",
                schema: "u",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScholingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schooling",
                schema: "u",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schooling", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolRecord",
                schema: "u",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "u",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SchoolingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SchoolRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Schooling_SchoolingId",
                        column: x => x.SchoolingId,
                        principalSchema: "u",
                        principalTable: "Schooling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_SchoolRecord_SchoolRecordId",
                        column: x => x.SchoolRecordId,
                        principalSchema: "u",
                        principalTable: "SchoolRecord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "u",
                table: "ScholingType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0850abfa-209e-4c0e-b83f-34e62e492a89"), "Médio" },
                    { new Guid("25ea9187-4a1f-4b9f-b5a8-7aec8dc0f839"), "Infantil" },
                    { new Guid("8a2d312d-e804-4f51-934a-fc5634c1940a"), "Fundamental" },
                    { new Guid("f67a3dac-3365-4994-abb8-5a9059c4e58f"), "Superior" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schooling_ReferenceId",
                schema: "u",
                table: "Schooling",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolRecord_ReferenceId",
                schema: "u",
                table: "SchoolRecord",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ReferenceId",
                schema: "u",
                table: "User",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_SchoolingId",
                schema: "u",
                table: "User",
                column: "SchoolingId");

            migrationBuilder.CreateIndex(
                name: "IX_User_SchoolRecordId",
                schema: "u",
                table: "User",
                column: "SchoolRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScholingType",
                schema: "u");

            migrationBuilder.DropTable(
                name: "User",
                schema: "u");

            migrationBuilder.DropTable(
                name: "Schooling",
                schema: "u");

            migrationBuilder.DropTable(
                name: "SchoolRecord",
                schema: "u");
        }
    }
}
