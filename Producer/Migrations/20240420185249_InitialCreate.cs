using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MAE_CORE");

            migrationBuilder.CreateTable(
                name: "QUOTE",
                schema: "MAE_CORE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PRODUCT_ID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PRICE = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUOTE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QUOTE",
                schema: "MAE_CORE");
        }
    }
}
