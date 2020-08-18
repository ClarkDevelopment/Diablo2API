using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diablo2API.Data.Models
{
    public class Classes
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Energy { get; set; }
        public decimal HealthPerVitalityPoint { get; set; }
        public decimal StaminaPerVitalityPoint { get; set; }
        public decimal ManaPerEnergyPoint { get; set; }
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