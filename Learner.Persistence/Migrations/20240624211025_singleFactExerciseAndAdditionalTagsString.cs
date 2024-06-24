using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learner.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class singleFactExerciseAndAdditionalTagsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SingleFactExercises",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleFactExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleFacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SingleFactExerciseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalTags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleFacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleFacts_SingleFactExercises_SingleFactExerciseId",
                        column: x => x.SingleFactExerciseId,
                        principalTable: "SingleFactExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleFacts_SingleFactExerciseId",
                table: "SingleFacts",
                column: "SingleFactExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SingleFacts");

            migrationBuilder.DropTable(
                name: "SingleFactExercises");
        }
    }
}
