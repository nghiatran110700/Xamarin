using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestPublishing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetType",
                columns: table => new
                {
                    AssetTypeK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetType", x => x.AssetTypeK);
                });

            migrationBuilder.CreateTable(
                name: "Tenancy",
                columns: table => new
                {
                    TenancyK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenancyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenancy", x => x.TenancyK);
                });

            migrationBuilder.CreateTable(
                name: "UserTB",
                columns: table => new
                {
                    UserK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTB", x => x.UserK);
                });

            migrationBuilder.CreateTable(
                name: "LocationTB",
                columns: table => new
                {
                    LocationK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenancyK = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTB", x => x.LocationK);
                    table.ForeignKey(
                        name: "FK_LocationTB_Tenancy_TenancyK",
                        column: x => x.TenancyK,
                        principalTable: "Tenancy",
                        principalColumn: "TenancyK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Asset",
                columns: table => new
                {
                    AccessK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Accessname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccessPercent = table.Column<double>(type: "float", nullable: true),
                    TimeRead = table.Column<double>(type: "float", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssetTypeK = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationK = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asset", x => x.AccessK);
                    table.ForeignKey(
                        name: "FK_Asset_AssetType_AssetTypeK",
                        column: x => x.AssetTypeK,
                        principalTable: "AssetType",
                        principalColumn: "AssetTypeK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Asset_LocationTB_LocationK",
                        column: x => x.LocationK,
                        principalTable: "LocationTB",
                        principalColumn: "LocationK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asset_AssetTypeK",
                table: "Asset",
                column: "AssetTypeK");

            migrationBuilder.CreateIndex(
                name: "IX_Asset_LocationK",
                table: "Asset",
                column: "LocationK");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTB_TenancyK",
                table: "LocationTB",
                column: "TenancyK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asset");

            migrationBuilder.DropTable(
                name: "UserTB");

            migrationBuilder.DropTable(
                name: "AssetType");

            migrationBuilder.DropTable(
                name: "LocationTB");

            migrationBuilder.DropTable(
                name: "Tenancy");
        }
    }
}
