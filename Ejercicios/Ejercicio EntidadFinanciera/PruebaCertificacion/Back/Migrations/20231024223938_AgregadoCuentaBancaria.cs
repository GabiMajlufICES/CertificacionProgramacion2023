using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoCuentaBancaria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dni",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CuentasBancarias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nroCuenta = table.Column<long>(type: "bigint", nullable: false),
                    saldo = table.Column<float>(type: "real", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteCuentaBancariaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentasBancarias", x => x.id);
                    table.ForeignKey(
                        name: "FK_CuentasBancarias_Clientes_clienteCuentaBancariaid",
                        column: x => x.clienteCuentaBancariaid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuentasBancarias_clienteCuentaBancariaid",
                table: "CuentasBancarias",
                column: "clienteCuentaBancariaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuentasBancarias");

            migrationBuilder.DropColumn(
                name: "dni",
                table: "Clientes");
        }
    }
}
