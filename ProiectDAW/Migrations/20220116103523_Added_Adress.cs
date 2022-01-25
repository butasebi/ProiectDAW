using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW.Migrations
{
    public partial class Added_Adress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceAutoAdresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Service_AutoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Street_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAutoAdresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAutoAdresses_Service_Autos_Service_AutoId",
                        column: x => x.Service_AutoId,
                        principalTable: "Service_Autos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAutoAdresses_Service_AutoId",
                table: "ServiceAutoAdresses",
                column: "Service_AutoId",
                unique: true,
                filter: "[Service_AutoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceAutoAdresses");
        }
    }
}
