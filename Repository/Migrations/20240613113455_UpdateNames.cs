using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotelrooms_type_TypeOfNumberId",
                table: "hotelrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_type",
                table: "type");

            migrationBuilder.RenameTable(
                name: "type",
                newName: "types");

            migrationBuilder.AddPrimaryKey(
                name: "PK_types",
                table: "types",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hotelrooms_types_TypeOfNumberId",
                table: "hotelrooms",
                column: "TypeOfNumberId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotelrooms_types_TypeOfNumberId",
                table: "hotelrooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_types",
                table: "types");

            migrationBuilder.RenameTable(
                name: "types",
                newName: "type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_type",
                table: "type",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_hotelrooms_type_TypeOfNumberId",
                table: "hotelrooms",
                column: "TypeOfNumberId",
                principalTable: "type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
