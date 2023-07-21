using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRolesData.Migrations
{
    public partial class addednewtableTicketStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketStatusId",
                table: "SupplierOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusId",
                table: "SupplierInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusId",
                table: "CustomerOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketStatusId",
                table: "CustomerInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TicketStatuses",
                columns: table => new
                {
                    TicketStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatuses", x => x.TicketStatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrders_TicketStatusId",
                table: "SupplierOrders",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierInvoices_TicketStatusId",
                table: "SupplierInvoices",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_TicketStatusId",
                table: "CustomerOrders",
                column: "TicketStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_TicketStatusId",
                table: "CustomerInvoices",
                column: "TicketStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInvoices_TicketStatuses_TicketStatusId",
                table: "CustomerInvoices",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "TicketStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerOrders_TicketStatuses_TicketStatusId",
                table: "CustomerOrders",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "TicketStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierInvoices_TicketStatuses_TicketStatusId",
                table: "SupplierInvoices",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "TicketStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierOrders_TicketStatuses_TicketStatusId",
                table: "SupplierOrders",
                column: "TicketStatusId",
                principalTable: "TicketStatuses",
                principalColumn: "TicketStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInvoices_TicketStatuses_TicketStatusId",
                table: "CustomerInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerOrders_TicketStatuses_TicketStatusId",
                table: "CustomerOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierInvoices_TicketStatuses_TicketStatusId",
                table: "SupplierInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierOrders_TicketStatuses_TicketStatusId",
                table: "SupplierOrders");

            migrationBuilder.DropTable(
                name: "TicketStatuses");

            migrationBuilder.DropIndex(
                name: "IX_SupplierOrders_TicketStatusId",
                table: "SupplierOrders");

            migrationBuilder.DropIndex(
                name: "IX_SupplierInvoices_TicketStatusId",
                table: "SupplierInvoices");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_TicketStatusId",
                table: "CustomerOrders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerInvoices_TicketStatusId",
                table: "CustomerInvoices");

            migrationBuilder.DropColumn(
                name: "TicketStatusId",
                table: "SupplierOrders");

            migrationBuilder.DropColumn(
                name: "TicketStatusId",
                table: "SupplierInvoices");

            migrationBuilder.DropColumn(
                name: "TicketStatusId",
                table: "CustomerOrders");

            migrationBuilder.DropColumn(
                name: "TicketStatusId",
                table: "CustomerInvoices");
        }
    }
}
