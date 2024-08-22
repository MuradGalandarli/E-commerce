using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccess.Commerce.Migrations
{
    /// <inheritdoc />
    public partial class CouponCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CouponDiscountedPrice",
                table: "Orders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CouponName",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherCampaignId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    SellerId = table.Column<int>(type: "integer", nullable: false),
                    GoodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_Goodses_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goodses",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponGoods",
                columns: table => new
                {
                    CouponGoodsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CouponName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponGoods", x => x.CouponGoodsId);
                });

            migrationBuilder.CreateTable(
                name: "OtherCampaigns",
                columns: table => new
                {
                    OtherCampaignId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GiftNumber = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfReceipts = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    GoodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCampaigns", x => x.OtherCampaignId);
                    table.ForeignKey(
                        name: "FK_OtherCampaigns_Goodses_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goodses",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponGoodsGoods",
                columns: table => new
                {
                    CouponGoodsId = table.Column<int>(type: "integer", nullable: false),
                    GoodsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponGoodsGoods", x => new { x.CouponGoodsId, x.GoodsId });
                    table.ForeignKey(
                        name: "FK_CouponGoodsGoods_CouponGoods_CouponGoodsId",
                        column: x => x.CouponGoodsId,
                        principalTable: "CouponGoods",
                        principalColumn: "CouponGoodsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponGoodsGoods_Goodses_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goodses",
                        principalColumn: "GoodsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_GoodsId",
                table: "Campaigns",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_SellerId",
                table: "Campaigns",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponGoodsGoods_GoodsId",
                table: "CouponGoodsGoods",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCampaigns_GoodsId",
                table: "OtherCampaigns",
                column: "GoodsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "CouponGoodsGoods");

            migrationBuilder.DropTable(
                name: "OtherCampaigns");

            migrationBuilder.DropTable(
                name: "CouponGoods");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CouponDiscountedPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CouponName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OtherCampaignId",
                table: "Orders");
        }
    }
}
