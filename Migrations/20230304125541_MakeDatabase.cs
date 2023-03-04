using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalisthenicsRoutineTracker.Migrations
{
    /// <inheritdoc />
    public partial class MakeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "date",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_date", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    set1_reps = table.Column<int>(type: "int", nullable: false),
                    set2_reps = table.Column<int>(type: "int", nullable: false),
                    set3_reps = table.Column<int>(type: "int", nullable: false),
                    set4_reps = table.Column<int>(type: "int", nullable: false),
                    DateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_date_DateId",
                        column: x => x.DateId,
                        principalTable: "date",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_DateId",
                table: "Workouts",
                column: "DateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "date");
        }
    }
}
