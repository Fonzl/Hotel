using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_citys_countries_CountryId",
                table: "citys");

            migrationBuilder.DropForeignKey(
                name: "FK_hotels_citys_CityId",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_citys",
                table: "citys");

            migrationBuilder.RenameTable(
                name: "citys",
                newName: "cities");

            migrationBuilder.RenameIndex(
                name: "IX_citys_CountryId",
                table: "cities",
                newName: "IX_cities_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryId",
                table: "cities",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_cities_CityId",
                table: "hotels",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryId",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_hotels_cities_CityId",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "citys");

            migrationBuilder.RenameIndex(
                name: "IX_cities_CountryId",
                table: "citys",
                newName: "IX_citys_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_citys",
                table: "citys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_citys_countries_CountryId",
                table: "citys",
                column: "CountryId",
                principalTable: "countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_citys_CityId",
                table: "hotels",
                column: "CityId",
                principalTable: "citys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
