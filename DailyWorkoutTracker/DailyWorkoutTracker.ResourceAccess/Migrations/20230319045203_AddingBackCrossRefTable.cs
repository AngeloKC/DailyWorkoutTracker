using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyWorkoutTracker.ResourceAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingBackCrossRefTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Exercises_ExerciseId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropIndex(
                name: "IX_MuscleGroups_ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_ExerciseId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "MuscleGroups");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Equipments");

            migrationBuilder.CreateTable(
                name: "ExerciseMuscleGroups",
                columns: table => new
                {
                    ExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    MuscleGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseMuscleGroups", x => new { x.ExerciseId, x.MuscleGroupId });
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroups_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseMuscleGroups_MuscleGroups_MuscleGroupId",
                        column: x => x.MuscleGroupId,
                        principalTable: "MuscleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseMuscleGroups_MuscleGroupId",
                table: "ExerciseMuscleGroups",
                column: "MuscleGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscleGroups");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "MuscleGroups",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Equipments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MuscleGroups_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_ExerciseId",
                table: "Equipments",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Exercises_ExerciseId",
                table: "Equipments",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleGroups_Exercises_ExerciseId",
                table: "MuscleGroups",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
