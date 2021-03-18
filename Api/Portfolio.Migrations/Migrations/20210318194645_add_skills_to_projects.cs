using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations.Migrations
{
    public partial class add_skills_to_projects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    SkillsId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.SkillsId, x.SkillsId1 });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_SkillsId1",
                        column: x => x.SkillsId1,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId1",
                table: "ProjectSkill",
                column: "SkillsId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSkill");
        }
    }
}
