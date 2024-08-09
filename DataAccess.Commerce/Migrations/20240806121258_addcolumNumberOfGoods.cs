using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Commerce.Migrations
{
    /// <inheritdoc />
    public partial class addcolumNumberOfGoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "NumberOfGoods",
                table: "Orders",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfGoods",
                table: "Orders");
        }
    }
}
