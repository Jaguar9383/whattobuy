using Microsoft.EntityFrameworkCore.Migrations;

namespace angular.Migrations
{
    public partial class add_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WhatToByListId",
                table: "Products",
                newName: "ToByListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToByListId",
                table: "Products",
                newName: "WhatToByListId");
        }
    }
}
