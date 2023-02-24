using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentWebAPIs.Migrations
{
    /// <inheritdoc />
    public partial class Addedrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_courses_InstructorId",
                table: "courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_instructors_InstructorId",
                table: "courses",
                column: "InstructorId",
                principalTable: "instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_instructors_InstructorId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_InstructorId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "courses");
        }
    }
}
