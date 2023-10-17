using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class RentsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rents_Books_BookId",
                table: "rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rents",
                table: "rents");

            migrationBuilder.RenameTable(
                name: "rents",
                newName: "Rents");

            migrationBuilder.RenameIndex(
                name: "IX_rents_BookId",
                table: "Rents",
                newName: "IX_Rents_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rents",
                table: "Rents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Books_BookId",
                table: "Rents",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Books_BookId",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rents",
                table: "Rents");

            migrationBuilder.RenameTable(
                name: "Rents",
                newName: "rents");

            migrationBuilder.RenameIndex(
                name: "IX_Rents_BookId",
                table: "rents",
                newName: "IX_rents_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rents",
                table: "rents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rents_Books_BookId",
                table: "rents",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
