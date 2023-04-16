using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.Infrastructure.Migrations
{
    public partial class fixduplicatefksremains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingEntries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingEntries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LogErrors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layer = table.Column<int>(type: "int", nullable: false),
                    DateLog = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErrors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    id_state = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.id_state);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    dni_type = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_accounting_entry = table.Column<int>(type: "int", nullable: false),
                    id_operation = table.Column<int>(type: "int", nullable: false),
                    id_previous_transaction = table.Column<int>(type: "int", nullable: false),
                    transaction_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    account_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    dni = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.id);
                    table.ForeignKey(
                        name: "FK_Movements_AccountingEntries_id_accounting_entry",
                        column: x => x.id_accounting_entry,
                        principalTable: "AccountingEntries",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Movements_Movements_id_previous_transaction",
                        column: x => x.id_previous_transaction,
                        principalTable: "Movements",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Movements_Operations_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Operations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false),
                    is_neo_bank = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Banks_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "FinancialProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_accounting_entry = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialProducts", x => x.id);
                    table.ForeignKey(
                        name: "FK_FinancialProducts_AccountingEntries_id_accounting_entry",
                        column: x => x.id_accounting_entry,
                        principalTable: "AccountingEntries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialProducts_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "IncomeCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_IncomeCategories_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "Periodicities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    amount_pay = table.Column<byte>(type: "tinyint", nullable: false),
                    amount_pay_year = table.Column<byte>(type: "tinyint", nullable: false),
                    month_unit = table.Column<byte>(type: "tinyint", nullable: false),
                    day_unit = table.Column<byte>(type: "tinyint", nullable: false),
                    is_fixed_intervar = table.Column<bool>(type: "bit", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodicities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Periodicities_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "SpentCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpentCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpentCategories_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Invalidated = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Token);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    claim_type = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    claim_value = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_financial_prod = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_bank = table.Column<int>(type: "int", nullable: false),
                    account_number = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Wallets_Banks_id_bank",
                        column: x => x.id_bank,
                        principalTable: "Banks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Wallets_FinancialProducts_id_financial_prod",
                        column: x => x.id_financial_prod,
                        principalTable: "FinancialProducts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Wallets_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_income_category = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_financial_product = table.Column<int>(type: "int", nullable: false),
                    idState = table.Column<int>(type: "int", nullable: false),
                    id_operation = table.Column<int>(type: "int", nullable: false),
                    transaction_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Incomes_FinancialProducts_id_financial_product",
                        column: x => x.id_financial_product,
                        principalTable: "FinancialProducts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Incomes_IncomeCategories_id_income_category",
                        column: x => x.id_income_category,
                        principalTable: "IncomeCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Incomes_Operations_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Operations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Incomes_States_idState",
                        column: x => x.idState,
                        principalTable: "States",
                        principalColumn: "id_state");
                    table.ForeignKey(
                        name: "FK_Incomes_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "SpentDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_spent_category = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpentDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpentDetail_SpentCategories_id_spent_category",
                        column: x => x.id_spent_category,
                        principalTable: "SpentCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SpentDetail_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "CashFlowFixeds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_operation = table.Column<int>(type: "int", nullable: false),
                    id_category = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_periodicity = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false),
                    SpentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowFixeds", x => x.id);
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_IncomeCategories_id_category",
                        column: x => x.id_category,
                        principalTable: "IncomeCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_Operations_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Operations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_Periodicities_id_periodicity",
                        column: x => x.id_periodicity,
                        principalTable: "Periodicities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_SpentCategories_SpentCategoryId",
                        column: x => x.SpentCategoryId,
                        principalTable: "SpentCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_SpentDetail_id_category",
                        column: x => x.id_category,
                        principalTable: "SpentDetail",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                    table.ForeignKey(
                        name: "FK_CashFlowFixeds_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Spents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_spent_detail = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_financial_product = table.Column<int>(type: "int", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false),
                    id_operation = table.Column<int>(type: "int", nullable: false),
                    transaction_number = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spents", x => x.id);
                    table.ForeignKey(
                        name: "FK_Spents_FinancialProducts_id_financial_product",
                        column: x => x.id_financial_product,
                        principalTable: "FinancialProducts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Spents_Operations_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Operations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Spents_SpentDetail_id_spent_detail",
                        column: x => x.id_spent_detail,
                        principalTable: "SpentDetail",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Spents_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                    table.ForeignKey(
                        name: "FK_Spents_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentDatePeriods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cash_flow_fixed = table.Column<int>(type: "int", nullable: false),
                    init_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    final_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    payment_date = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDatePeriods", x => x.id);
                    table.ForeignKey(
                        name: "FK_PaymentDatePeriods_CashFlowFixeds_id_cash_flow_fixed",
                        column: x => x.id_cash_flow_fixed,
                        principalTable: "CashFlowFixeds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PaymentDatePeriods_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateTable(
                name: "TransactionFixeds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cash_flow_fixed = table.Column<int>(type: "int", nullable: false),
                    id_operation = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    id_state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionFixeds", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionFixeds_CashFlowFixeds_id_cash_flow_fixed",
                        column: x => x.id_cash_flow_fixed,
                        principalTable: "CashFlowFixeds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionFixeds_Incomes_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Incomes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionFixeds_Spents_id_operation",
                        column: x => x.id_operation,
                        principalTable: "Spents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionFixeds_States_id_state",
                        column: x => x.id_state,
                        principalTable: "States",
                        principalColumn: "id_state");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_id_state",
                table: "Banks",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_id_category",
                table: "CashFlowFixeds",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_id_operation",
                table: "CashFlowFixeds",
                column: "id_operation");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_id_periodicity",
                table: "CashFlowFixeds",
                column: "id_periodicity");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_id_state",
                table: "CashFlowFixeds",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_id_user",
                table: "CashFlowFixeds",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowFixeds_SpentCategoryId",
                table: "CashFlowFixeds",
                column: "SpentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialProducts_id_accounting_entry",
                table: "FinancialProducts",
                column: "id_accounting_entry");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialProducts_id_state",
                table: "FinancialProducts",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeCategories_id_state",
                table: "IncomeCategories",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_id_financial_product",
                table: "Incomes",
                column: "id_financial_product");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_id_income_category",
                table: "Incomes",
                column: "id_income_category");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_id_operation",
                table: "Incomes",
                column: "id_operation");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_id_user",
                table: "Incomes",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_idState",
                table: "Incomes",
                column: "idState");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_id_accounting_entry",
                table: "Movements",
                column: "id_accounting_entry");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_id_operation",
                table: "Movements",
                column: "id_operation");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_id_previous_transaction",
                table: "Movements",
                column: "id_previous_transaction",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDatePeriods_id_cash_flow_fixed",
                table: "PaymentDatePeriods",
                column: "id_cash_flow_fixed");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDatePeriods_id_state",
                table: "PaymentDatePeriods",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_Periodicities_id_state",
                table: "Periodicities",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpentCategories_id_state",
                table: "SpentCategories",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_SpentDetail_id_spent_category",
                table: "SpentDetail",
                column: "id_spent_category");

            migrationBuilder.CreateIndex(
                name: "IX_SpentDetail_id_state",
                table: "SpentDetail",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_Spents_id_financial_product",
                table: "Spents",
                column: "id_financial_product");

            migrationBuilder.CreateIndex(
                name: "IX_Spents_id_operation",
                table: "Spents",
                column: "id_operation");

            migrationBuilder.CreateIndex(
                name: "IX_Spents_id_spent_detail",
                table: "Spents",
                column: "id_spent_detail");

            migrationBuilder.CreateIndex(
                name: "IX_Spents_id_state",
                table: "Spents",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_Spents_id_user",
                table: "Spents",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFixeds_id_cash_flow_fixed",
                table: "TransactionFixeds",
                column: "id_cash_flow_fixed");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFixeds_id_operation",
                table: "TransactionFixeds",
                column: "id_operation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionFixeds_id_state",
                table: "TransactionFixeds",
                column: "id_state");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_id_user",
                table: "UserClaims",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_id_bank",
                table: "Wallets",
                column: "id_bank");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_id_financial_prod",
                table: "Wallets",
                column: "id_financial_prod");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_id_user",
                table: "Wallets",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogErrors");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "PaymentDatePeriods");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "TransactionFixeds");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "CashFlowFixeds");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Spents");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Periodicities");

            migrationBuilder.DropTable(
                name: "IncomeCategories");

            migrationBuilder.DropTable(
                name: "FinancialProducts");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "SpentDetail");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AccountingEntries");

            migrationBuilder.DropTable(
                name: "SpentCategories");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
