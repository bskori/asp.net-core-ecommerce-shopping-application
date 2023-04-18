using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class deleteSubCtegory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategoryTbl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCategoryTbl",
                columns: table => new
                {
                    SubCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<long>(type: "bigint", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryTbl", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategoryTbl_CategoryTbl_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "CategoryTbl",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryTbl_CategoryID",
                table: "SubCategoryTbl",
                column: "CategoryID");
        }
    }
}
