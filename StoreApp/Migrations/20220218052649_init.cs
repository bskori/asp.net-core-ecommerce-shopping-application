using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispatchAgencyTbl",
                columns: table => new
                {
                    DispatchAgencyID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchAgencyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchAgencyTbl", x => x.DispatchAgencyID);
                });

            migrationBuilder.CreateTable(
                name: "MainCategoryTbl",
                columns: table => new
                {
                    MainCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategoryTbl", x => x.MainCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "StoreTbl",
                columns: table => new
                {
                    StoreID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreTbl", x => x.StoreID);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTbl",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategoryID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTbl", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_CategoryTbl_MainCategoryTbl_MainCategoryID",
                        column: x => x.MainCategoryID,
                        principalTable: "MainCategoryTbl",
                        principalColumn: "MainCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrderTbl",
                columns: table => new
                {
                    UserOrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderTbl", x => x.UserOrderID);
                    table.ForeignKey(
                        name: "FK_UserOrderTbl_UserTbl_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTbl",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTbl",
                columns: table => new
                {
                    ProductID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MfgName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    UserOrderID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTbl", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_ProductTbl_CategoryTbl_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryTbl",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTbl_UserOrderTbl_UserOrderID",
                        column: x => x.UserOrderID,
                        principalTable: "UserOrderTbl",
                        principalColumn: "UserOrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOrderDispatchTbl",
                columns: table => new
                {
                    UserOrderDispatchID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserOrderID = table.Column<long>(type: "bigint", nullable: false),
                    DispatchAgencyID = table.Column<long>(type: "bigint", nullable: false),
                    DocketNo = table.Column<long>(type: "bigint", nullable: false),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedReachDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderDispatchTbl", x => x.UserOrderDispatchID);
                    table.ForeignKey(
                        name: "FK_UserOrderDispatchTbl_DispatchAgencyTbl_DispatchAgencyID",
                        column: x => x.DispatchAgencyID,
                        principalTable: "DispatchAgencyTbl",
                        principalColumn: "DispatchAgencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrderDispatchTbl_UserOrderTbl_UserOrderID",
                        column: x => x.UserOrderID,
                        principalTable: "UserOrderTbl",
                        principalColumn: "UserOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOrderDetailsTbl",
                columns: table => new
                {
                    UserOrderDetID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserOrderID = table.Column<long>(type: "bigint", nullable: false),
                    ProductID = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderDetailsTbl", x => x.UserOrderDetID);
                    table.ForeignKey(
                        name: "FK_UserOrderDetailsTbl_ProductTbl_ProductID",
                        column: x => x.ProductID,
                        principalTable: "ProductTbl",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOrderDetailsTbl_UserOrderTbl_UserOrderID",
                        column: x => x.UserOrderID,
                        principalTable: "UserOrderTbl",
                        principalColumn: "UserOrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTbl_MainCategoryID",
                table: "CategoryTbl",
                column: "MainCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbl_CategoryID",
                table: "ProductTbl",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTbl_UserOrderID",
                table: "ProductTbl",
                column: "UserOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderDetailsTbl_ProductID",
                table: "UserOrderDetailsTbl",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderDetailsTbl_UserOrderID",
                table: "UserOrderDetailsTbl",
                column: "UserOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderDispatchTbl_DispatchAgencyID",
                table: "UserOrderDispatchTbl",
                column: "DispatchAgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderDispatchTbl_UserOrderID",
                table: "UserOrderDispatchTbl",
                column: "UserOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderTbl_UserID",
                table: "UserOrderTbl",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreTbl");

            migrationBuilder.DropTable(
                name: "UserOrderDetailsTbl");

            migrationBuilder.DropTable(
                name: "UserOrderDispatchTbl");

            migrationBuilder.DropTable(
                name: "ProductTbl");

            migrationBuilder.DropTable(
                name: "DispatchAgencyTbl");

            migrationBuilder.DropTable(
                name: "CategoryTbl");

            migrationBuilder.DropTable(
                name: "UserOrderTbl");

            migrationBuilder.DropTable(
                name: "MainCategoryTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");
        }
    }
}
