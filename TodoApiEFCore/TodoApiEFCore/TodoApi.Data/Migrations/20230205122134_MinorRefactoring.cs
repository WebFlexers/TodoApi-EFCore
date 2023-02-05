using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class MinorRefactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Todos_TodosModelTodosId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodosModelTodosId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "TodosModelTodosId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "TodosStatus",
                table: "Todos",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "TodosName",
                table: "Todos",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TodosDescription",
                table: "Todos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TodosId",
                table: "Todos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ItemStatus",
                table: "TodoItems",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ItemDescription",
                table: "TodoItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "TodoItems",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodosId",
                table: "TodoItems",
                column: "TodosId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Todos_TodosId",
                table: "TodoItems",
                column: "TodosId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Todos_TodosId",
                table: "TodoItems");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_TodosId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Todos",
                newName: "TodosStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Todos",
                newName: "TodosName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Todos",
                newName: "TodosDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Todos",
                newName: "TodosId");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TodoItems",
                newName: "ItemStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoItems",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TodoItems",
                newName: "ItemDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TodoItems",
                newName: "ItemId");

            migrationBuilder.AddColumn<int>(
                name: "TodosModelTodosId",
                table: "TodoItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_TodosModelTodosId",
                table: "TodoItems",
                column: "TodosModelTodosId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Todos_TodosModelTodosId",
                table: "TodoItems",
                column: "TodosModelTodosId",
                principalTable: "Todos",
                principalColumn: "TodosId");
        }
    }
}
