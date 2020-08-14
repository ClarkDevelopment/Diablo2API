using System;
using System.Collections.Generic;

namespace Diablo2API.Data.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
        public int HealthPerVitalityPoint { get; set; }
        public int StaminaPerVitalityPoint { get; set; }
        public int ManaPerEnergyPoint { get; set; }
        public StatsPerLevel StatsPerLevel { get; set; }

    }

    public class StatsPerLevel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Stamina { get; set; }
        public int Mana { get; set; }
    }
}