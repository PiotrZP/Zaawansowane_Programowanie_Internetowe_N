using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.DAL.Migrations
{
    public partial class AddressFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StationaryStore_StationaryStoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StationaryStore_Addresses_AddressId",
                table: "StationaryStore");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StationaryStore_StationaryStoreId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationaryStore",
                table: "StationaryStore");

            migrationBuilder.RenameTable(
                name: "StationaryStore",
                newName: "StationaryStores");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.RenameIndex(
                name: "IX_StationaryStore_AddressId",
                table: "StationaryStores",
                newName: "IX_StationaryStores_AddressId");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationaryStores",
                table: "StationaryStores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StationaryStores_StationaryStoreId",
                table: "Orders",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StationaryStores_Addresses_AddressId",
                table: "StationaryStores",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StationaryStores_StationaryStoreId",
                table: "Users",
                column: "StationaryStoreId",
                principalTable: "StationaryStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_StationaryStores_StationaryStoreId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_StationaryStores_Addresses_AddressId",
                table: "StationaryStores");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_StationaryStores_StationaryStoreId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StationaryStores",
                table: "StationaryStores");

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "StationaryStores",
                newName: "StationaryStore");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameIndex(
                name: "IX_StationaryStores_AddressId",
                table: "StationaryStore",
                newName: "IX_StationaryStore_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StationaryStore",
                table: "StationaryStore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_StationaryStore_StationaryStoreId",
                table: "Orders",
                column: "StationaryStoreId",
                principalTable: "StationaryStore",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StationaryStore_Addresses_AddressId",
                table: "StationaryStore",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StationaryStore_StationaryStoreId",
                table: "Users",
                column: "StationaryStoreId",
                principalTable: "StationaryStore",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
