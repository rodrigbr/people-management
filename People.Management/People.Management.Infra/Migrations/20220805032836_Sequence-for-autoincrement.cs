using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace People.Management.Infra.Migrations
{
    public partial class Sequenceforautoincrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ReferenceId");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                schema: "u",
                table: "User",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR ReferenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "ReferenceId");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                schema: "u",
                table: "User");
        }
    }
}
