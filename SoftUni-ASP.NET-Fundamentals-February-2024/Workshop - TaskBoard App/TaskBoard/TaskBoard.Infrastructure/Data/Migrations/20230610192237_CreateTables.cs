using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskBoard.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { new Guid("144d9693-32d1-4629-bfc7-f4f56206699f"), 1, new DateTime(2023, 1, 10, 19, 22, 37, 454, DateTimeKind.Utc).AddTicks(3397), "Create Android client App for the RESTful TaskBoard service", "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609", "Android Client App" },
                    { new Guid("19aa65ad-9c0c-460b-ba59-e846b6b5afb9"), 3, new DateTime(2022, 6, 10, 19, 22, 37, 454, DateTimeKind.Utc).AddTicks(3403), "Implement [Create Task] page for adding tasks", "fd276457-f3b5-4f2a-a452-11a81bc8764c", "Create Tasks" },
                    { new Guid("36bf2318-66c9-4687-8ef0-e8b5d626a411"), 1, new DateTime(2022, 11, 22, 19, 22, 37, 454, DateTimeKind.Utc).AddTicks(3374), "Implement better styling for all public pages", "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609", "Improve CSS styles" },
                    { new Guid("cf52f08d-82a0-4a39-a3b8-c6dbbbef8dec"), 2, new DateTime(2023, 5, 10, 19, 22, 37, 454, DateTimeKind.Utc).AddTicks(3401), "Create Desktop client App for the RESTful TaskBoard service", "07bf414a-5aba-4b74-b0b8-aa9c2f0d1609", "Desktop Client App" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
