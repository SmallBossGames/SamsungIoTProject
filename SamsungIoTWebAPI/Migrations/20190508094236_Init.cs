using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamsungIoTWebAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoilerStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    HeatCarrierTemperature = table.Column<float>(nullable: false),
                    LeakOfGasSatus = table.Column<bool>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoilerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomStatus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomNumber = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Temperature = table.Column<float>(nullable: false),
                    AirHumidity = table.Column<float>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoilerStatus");

            migrationBuilder.DropTable(
                name: "RoomStatus");
        }
    }
}
