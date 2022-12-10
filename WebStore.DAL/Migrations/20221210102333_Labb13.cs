using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebStore.DAL.Migrations
{
    public partial class Labb13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Addresses",
                newName: "BuildingNumber");

            migrationBuilder.RenameColumn(
                name: "StreetName",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "PostCode",
                table: "Addresses",
                newName: "Street");

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNumber",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Addresses",
                newName: "StreetName");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "PostCode");

            migrationBuilder.RenameColumn(
                name: "BuildingNumber",
                table: "Addresses",
                newName: "StreetNumber");
        }
    }
}
