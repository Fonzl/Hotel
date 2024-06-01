using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMedia",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "IdMedia",
                table: "hotelrooms");

            migrationBuilder.DropColumn(
                name: "IdMedia",
                table: "hotelchains");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "hotels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Stars",
                table: "hotels",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "Stars",
                table: "hotels");

            migrationBuilder.AddColumn<long>(
                name: "IdMedia",
                table: "hotels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "hotels",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "IdMedia",
                table: "hotelrooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "IdMedia",
                table: "hotelchains",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
