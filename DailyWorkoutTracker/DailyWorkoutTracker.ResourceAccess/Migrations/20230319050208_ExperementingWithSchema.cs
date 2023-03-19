﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyWorkoutTracker.ResourceAccess.Migrations
{
    /// <inheritdoc />
    public partial class ExperementingWithSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MuscleGroups",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MuscleGroups");
        }
    }
}