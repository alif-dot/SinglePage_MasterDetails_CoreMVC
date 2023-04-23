using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinglePage_MasterDetails.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<long>(type: "bigint", nullable: true),
                    ProductName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailId);
                });

            migrationBuilder.CreateTable(
                name: "SaleMaster",
                columns: table => new
                {
                    SaleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustomerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustomerAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SaleMast__1EE3C3FFAD2CEC3D", x => x.SaleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "SaleMaster");
        }
    }
}
