using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SingalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_orderdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "OrderDate",
                table: "Orders",
                type: "date",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");
        }
    }
}
