using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW.Migrations
{
    public partial class testtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AutoClient_Clients_ClientId",
                table: "Service_AutoClient");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AutoClient_Service_Autos_Service_AutoId",
                table: "Service_AutoClient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_AutoClient",
                table: "Service_AutoClient");

            migrationBuilder.RenameTable(
                name: "Service_AutoClient",
                newName: "Service_AutoClients");

            migrationBuilder.RenameIndex(
                name: "IX_Service_AutoClient_ClientId",
                table: "Service_AutoClients",
                newName: "IX_Service_AutoClients_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_AutoClients",
                table: "Service_AutoClients",
                columns: new[] { "Service_AutoId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AutoClients_Clients_ClientId",
                table: "Service_AutoClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AutoClients_Service_Autos_Service_AutoId",
                table: "Service_AutoClients",
                column: "Service_AutoId",
                principalTable: "Service_Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_AutoClients_Clients_ClientId",
                table: "Service_AutoClients");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AutoClients_Service_Autos_Service_AutoId",
                table: "Service_AutoClients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service_AutoClients",
                table: "Service_AutoClients");

            migrationBuilder.RenameTable(
                name: "Service_AutoClients",
                newName: "Service_AutoClient");

            migrationBuilder.RenameIndex(
                name: "IX_Service_AutoClients_ClientId",
                table: "Service_AutoClient",
                newName: "IX_Service_AutoClient_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service_AutoClient",
                table: "Service_AutoClient",
                columns: new[] { "Service_AutoId", "ClientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AutoClient_Clients_ClientId",
                table: "Service_AutoClient",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AutoClient_Service_Autos_Service_AutoId",
                table: "Service_AutoClient",
                column: "Service_AutoId",
                principalTable: "Service_Autos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
