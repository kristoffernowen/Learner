using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learner.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactObjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExerciseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactObjects_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactObjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_FactObjects_FactObjectId",
                        column: x => x.FactObjectId,
                        principalTable: "FactObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FactObjects_ExerciseId",
                table: "FactObjects",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_FactObjectId",
                table: "Facts",
                column: "FactObjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facts");

            migrationBuilder.DropTable(
                name: "FactObjects");

            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
