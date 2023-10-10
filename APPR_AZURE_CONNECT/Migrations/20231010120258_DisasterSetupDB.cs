using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APPR_AZURE_CONNECT.Migrations
{
    /// <inheritdoc />
    public partial class DisasterSetupDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disasters",
                columns: table => new
                {
                    DisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredAidTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocateGoods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllocateMoney = table.Column<int>(type: "int", nullable: false),
                    AllocatedMoneyLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disasters", x => x.DisId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disasters");
        }
    }
}
