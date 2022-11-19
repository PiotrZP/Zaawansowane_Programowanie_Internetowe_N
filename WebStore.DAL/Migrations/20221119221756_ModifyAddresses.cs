using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.DAL.Migrations
{
    public partial class ModifyAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StationaryStoreId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StationaryStoreId",
                table: "Addresses",
                column: "StationaryStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StationaryStores_StationaryStoreId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StationaryStoreId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StationaryStoreId",
                table: "Addresses");
        }
    }
}
