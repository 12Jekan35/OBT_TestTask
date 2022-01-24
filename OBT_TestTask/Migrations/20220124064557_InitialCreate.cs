using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OBT_TestTask.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "ChangesDebt",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllSum = table.Column<decimal>(type: "numeric", nullable: false),
                    NonmonetaryPart = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangesDebt", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AllSum = table.Column<decimal>(type: "numeric", nullable: false),
                    LongTerm = table.Column<decimal>(type: "numeric", nullable: false),
                    Overdue = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BudgetAccounts",
                schema: "public",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: true),
                    FormNumber = table.Column<int>(type: "integer", nullable: false),
                    SintAccount = table.Column<string>(type: "text", nullable: true),
                    KOSGU = table.Column<string>(type: "text", nullable: true),
                    StartYearDebtID = table.Column<int>(type: "integer", nullable: false),
                    ChangeUpDebtID = table.Column<int>(type: "integer", nullable: false),
                    ChangeDownDebtID = table.Column<int>(type: "integer", nullable: false),
                    EndReportPeriodDebtID = table.Column<int>(type: "integer", nullable: false),
                    EndSamePastPeriodID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BudgetAccounts_ChangesDebt_ChangeDownDebtID",
                        column: x => x.ChangeDownDebtID,
                        principalSchema: "public",
                        principalTable: "ChangesDebt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetAccounts_ChangesDebt_ChangeUpDebtID",
                        column: x => x.ChangeUpDebtID,
                        principalSchema: "public",
                        principalTable: "ChangesDebt",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetAccounts_Debts_EndReportPeriodDebtID",
                        column: x => x.EndReportPeriodDebtID,
                        principalSchema: "public",
                        principalTable: "Debts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetAccounts_Debts_EndSamePastPeriodID",
                        column: x => x.EndSamePastPeriodID,
                        principalSchema: "public",
                        principalTable: "Debts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BudgetAccounts_Debts_StartYearDebtID",
                        column: x => x.StartYearDebtID,
                        principalSchema: "public",
                        principalTable: "Debts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAccounts_ChangeDownDebtID",
                schema: "public",
                table: "BudgetAccounts",
                column: "ChangeDownDebtID");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAccounts_ChangeUpDebtID",
                schema: "public",
                table: "BudgetAccounts",
                column: "ChangeUpDebtID");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAccounts_EndReportPeriodDebtID",
                schema: "public",
                table: "BudgetAccounts",
                column: "EndReportPeriodDebtID");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAccounts_EndSamePastPeriodID",
                schema: "public",
                table: "BudgetAccounts",
                column: "EndSamePastPeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetAccounts_StartYearDebtID",
                schema: "public",
                table: "BudgetAccounts",
                column: "StartYearDebtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetAccounts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "ChangesDebt",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Debts",
                schema: "public");
        }
    }
}
