using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EL_KooD_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<Point>(type: "geography", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main_Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Main_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Secondary_Branches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Secondary_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Secondary_Branches_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturing_Processes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Main_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturing_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturing_Processes_Main_Branches_Main_BranchId",
                        column: x => x.Main_BranchId,
                        principalTable: "Main_Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Manufacturing_Processes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Supply_Processes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Secondary_BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Manufacturing_ProcessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supply_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supply_Processes_Manufacturing_Processes_Manufacturing_ProcessId",
                        column: x => x.Manufacturing_ProcessId,
                        principalTable: "Manufacturing_Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Supply_Processes_Secondary_Branches_Secondary_BranchId",
                        column: x => x.Secondary_BranchId,
                        principalTable: "Secondary_Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Main_Branches_CompanyId",
                table: "Main_Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturing_Processes_Main_BranchId",
                table: "Manufacturing_Processes",
                column: "Main_BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturing_Processes_ProductId",
                table: "Manufacturing_Processes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Secondary_Branches_CompanyId",
                table: "Secondary_Branches",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Processes_Manufacturing_ProcessId",
                table: "Supply_Processes",
                column: "Manufacturing_ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_Processes_Secondary_BranchId",
                table: "Supply_Processes",
                column: "Secondary_BranchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supply_Processes");

            migrationBuilder.DropTable(
                name: "Manufacturing_Processes");

            migrationBuilder.DropTable(
                name: "Secondary_Branches");

            migrationBuilder.DropTable(
                name: "Main_Branches");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
