using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopMicroservices.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceInCents = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created_at", "Name" },
                values: new object[,]
                {
                    { new Guid("44d1f9c1-2fd2-4941-93e0-a8af000f4623"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9526), "Bebidas" },
                    { new Guid("a1a8ad4a-294d-406f-b854-355ae5b2ca19"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9538), "Salgados" },
                    { new Guid("c07c2148-0093-46a5-8638-ba58f7ee1649"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9539), "Doces" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Created_at", "Description", "ImageUrl", "Name", "PriceInCents", "Stock" },
                values: new object[,]
                {
                    { new Guid("0f2b29b5-8826-4891-9998-ea51d588a0ca"), new Guid("a1a8ad4a-294d-406f-b854-355ae5b2ca19"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9621), "queijo e presunto", "joelho.jpg", "Joelho", 600, 100L },
                    { new Guid("6fda4adf-ab64-4710-8e40-09119064fca2"), new Guid("44d1f9c1-2fd2-4941-93e0-a8af000f4623"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9619), "da fruta", "suco_de_caju.jpg", "Suco de caju", 800, 100L },
                    { new Guid("d60782a1-7fb9-4dce-b5ee-b8ae439db768"), new Guid("c07c2148-0093-46a5-8638-ba58f7ee1649"), new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9623), "de chocolate", "sorvete_de_chocolate.jpg", "Sorvete", 1000, 100L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
