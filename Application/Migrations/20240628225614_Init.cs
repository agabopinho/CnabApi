using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Transaction",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                TransactionType = table.Column<int>(type: "int", nullable: false),
                OccurrenceAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                Value = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                LegalDocument = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                CardNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                StoreOwner = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                StoreName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transaction", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Transaction");
    }
}
