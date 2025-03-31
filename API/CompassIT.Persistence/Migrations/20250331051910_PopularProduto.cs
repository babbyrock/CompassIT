using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompassIT.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PopularProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Nome", "Preco", "Quantidade" },
                values: new object[,]
                {
            { "Produto A", 10.50, 100 },
            { "Produto B", 20.00, 200 },
            { "Produto C", 30.75, 300 }
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
