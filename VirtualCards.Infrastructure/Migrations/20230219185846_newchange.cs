using Microsoft.EntityFrameworkCore.Migrations;

namespace VirtualCards.Infrastructure.Migrations
{
    public partial class newchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRequestandResponse",
                table: "tblRequestandResponse");

            migrationBuilder.RenameTable(
                name: "tblRequestandResponse",
                newName: "tblRequestAndResponse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRequestAndResponse",
                table: "tblRequestAndResponse",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRequestAndResponse",
                table: "tblRequestAndResponse");

            migrationBuilder.RenameTable(
                name: "tblRequestAndResponse",
                newName: "tblRequestandResponse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRequestandResponse",
                table: "tblRequestandResponse",
                column: "Id");
        }
    }
}
