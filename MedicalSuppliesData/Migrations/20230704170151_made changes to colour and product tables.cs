﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRolesData.Migrations
{
    public partial class madechangestocolourandproducttables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ColourId",
                table: "Products",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Colours_ColourId",
                table: "Products",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Colours_ColourId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ColourId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "Products");
        }
    }
}
