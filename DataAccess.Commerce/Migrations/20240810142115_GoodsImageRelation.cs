using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Commerce.Migrations
{
    /// <inheritdoc />
    public partial class GoodsImageRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goodses_Images_Imageid",
                table: "Goodses");

            migrationBuilder.DropIndex(
                name: "IX_Goodses_Imageid",
                table: "Goodses");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "Goodses");

            migrationBuilder.AddColumn<int>(
                name: "GoodsId",
                table: "Images",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_GoodsId",
                table: "Images",
                column: "GoodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Goodses_GoodsId",
                table: "Images",
                column: "GoodsId",
                principalTable: "Goodses",
                principalColumn: "GoodsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Goodses_GoodsId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_GoodsId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "GoodsId",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "Goodses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goodses_Imageid",
                table: "Goodses",
                column: "Imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Goodses_Images_Imageid",
                table: "Goodses",
                column: "Imageid",
                principalTable: "Images",
                principalColumn: "ImageId");
        }
    }
}
