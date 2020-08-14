using System.Collections.Generic;
using Diablo2API.Data.Models;

public class Skill
{
    public int Id { get; set; }
    public SkillTree SkillTree { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SkillTraitsByLevel SkillTraits { get; set; }
    public List<SynergyBonus> SynergyBonuses { get; set; }
    public List<PrerequisiteSkill> PrerequisiteSkills { get; set; }
}

public class SkillTraitsByLevel
{
    public int Id { get; set; }
    public int Level { get; set; }
    public int ManaCost { get; set; }
    public int Radius { get; set; }
    public int DamageType { get; set; }
    public int MinimumDamage { get; set; }
    public int MaximumDamage { get; set; }
    public int AttackPercentageIncrease { get; set; }
    public int AttackSpeedPercentageIncrease { get; set; }
    public int DamagePercentageIncrease { get; set; }
    public int DefensePercentageIncrease { get; set; }
    public int WalkRunSpeedPercentageIncrease { get; set; }
    public int DurationInSeconds { get; set; }
}

public class SynergyBonus
{
    public int Id { get; set; }
    public Skill Skill { get; set; }
    public int BonusPercentage { get; set; }
}

public class PrerequisiteSkill
{
    public int Id { get; set; }
    public int TotalSkillTreePoints { get; set; }
}