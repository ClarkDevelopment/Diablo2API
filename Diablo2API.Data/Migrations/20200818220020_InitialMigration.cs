using Microsoft.EntityFrameworkCore.Migrations;

namespace Diablo2API.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillTraitsByLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(nullable: false),
                    ManaCost = table.Column<int>(nullable: false),
                    Radius = table.Column<int>(nullable: false),
                    DamageType = table.Column<int>(nullable: false),
                    MinimumDamage = table.Column<int>(nullable: false),
                    MaximumDamage = table.Column<int>(nullable: false),
                    AttackPercentageIncrease = table.Column<int>(nullable: false),
                    AttackSpeedPercentageIncrease = table.Column<int>(nullable: false),
                    DamagePercentageIncrease = table.Column<int>(nullable: false),
                    DefensePercentageIncrease = table.Column<int>(nullable: false),
                    WalkRunSpeedPercentageIncrease = table.Column<int>(nullable: false),
                    DurationInSeconds = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTraitsByLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatsPerLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(nullable: false),
                    Health = table.Column<int>(nullable: false),
                    Stamina = table.Column<int>(nullable: false),
                    Mana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsPerLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Dexterity = table.Column<int>(nullable: false),
                    Vitality = table.Column<int>(nullable: false),
                    Energy = table.Column<int>(nullable: false),
                    HealthPerVitalityPoint = table.Column<decimal>(nullable: false),
                    StaminaPerVitalityPoint = table.Column<decimal>(nullable: false),
                    ManaPerEnergyPoint = table.Column<decimal>(nullable: false),
                    StatsPerLevelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_StatsPerLevel_StatsPerLevelId",
                        column: x => x.StatsPerLevelId,
                        principalTable: "StatsPerLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SkillTrees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillTrees_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillTreeId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PassiveEffect = table.Column<string>(nullable: true),
                    RequiredLevel = table.Column<int>(nullable: false),
                    SkillTraitsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_SkillTraitsByLevel_SkillTraitsId",
                        column: x => x.SkillTraitsId,
                        principalTable: "SkillTraitsByLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Skills_SkillTrees_SkillTreeId",
                        column: x => x.SkillTreeId,
                        principalTable: "SkillTrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrerequisiteSkill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSkillTreePoints = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrerequisiteSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrerequisiteSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SynergyBonus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(nullable: true),
                    BonusPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SynergyBonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SynergyBonus_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_StatsPerLevelId",
                table: "Classes",
                column: "StatsPerLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_PrerequisiteSkill_SkillId",
                table: "PrerequisiteSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillTraitsId",
                table: "Skills",
                column: "SkillTraitsId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillTreeId",
                table: "Skills",
                column: "SkillTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTrees_ClassId",
                table: "SkillTrees",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SynergyBonus_SkillId",
                table: "SynergyBonus",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrerequisiteSkill");

            migrationBuilder.DropTable(
                name: "SynergyBonus");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SkillTraitsByLevel");

            migrationBuilder.DropTable(
                name: "SkillTrees");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "StatsPerLevel");
        }
    }
}
