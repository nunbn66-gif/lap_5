using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NsbmLesson12.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    NsbmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nsbmname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NsbmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.NsbmId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    NsbmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NsbmName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NsbmImage = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    NsbmPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NsbmsalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NsbmStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Descriptions = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    NsbmCategoryId = table.Column<int>(type: "int", nullable: false),
                    NsbmCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.NsbmId);
                    table.ForeignKey(
                        name: "FK_Product_Category_NsbmCategoryId",
                        column: x => x.NsbmCategoryId,
                        principalTable: "Category",
                        principalColumn: "NsbmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_NsbmCategoryId",
                table: "Product",
                column: "NsbmCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
