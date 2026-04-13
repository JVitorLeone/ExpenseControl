using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseControl.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PersonId",
                table: "Transactions",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Persons_PersonId",
                table: "Transactions",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Categories_Purpose",
                table: "Categories",
                sql: "Purpose IN (0, 1, 2)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transactions_Type",
                table: "Transactions",
                sql: "Type IN (0, 1)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Transactions_Value",
                table: "Transactions",
                sql: "Value > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Categories_CategoryId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Persons_PersonId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_PersonId",
                table: "Transactions");
        }
    }
}
