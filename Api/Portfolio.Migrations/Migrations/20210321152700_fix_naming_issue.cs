using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations.Migrations
{
    public partial class fix_naming_issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSkill_Projects_SkillsId",
                table: "ProjectSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSkill_Skills_SkillsId1",
                table: "ProjectSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSkill",
                table: "ProjectSkill");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSkill_SkillsId1",
                table: "ProjectSkill");

            migrationBuilder.RenameColumn(
                name: "SkillsId1",
                table: "ProjectSkill",
                newName: "ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSkill",
                table: "ProjectSkill",
                columns: new[] { "ProjectsId", "SkillsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSkill_Projects_ProjectsId",
                table: "ProjectSkill",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSkill_Skills_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSkill_Projects_ProjectsId",
                table: "ProjectSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSkill_Skills_SkillsId",
                table: "ProjectSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectSkill",
                table: "ProjectSkill");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSkill_SkillsId",
                table: "ProjectSkill");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectSkill",
                newName: "SkillsId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectSkill",
                table: "ProjectSkill",
                columns: new[] { "SkillsId", "SkillsId1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId1",
                table: "ProjectSkill",
                column: "SkillsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSkill_Projects_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSkill_Skills_SkillsId1",
                table: "ProjectSkill",
                column: "SkillsId1",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
