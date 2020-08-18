using System.Data.Common;
using Diablo2API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Diablo2API.Data
{
    public class DiabloDbContext : DbContext
    {
        public DiabloDbContext(DbContextOptions<DiabloDbContext> options) 
            : base(options)
        {

        }
        
        public DbSet<Classes> Classes { get; set; }

        public DbSet<SkillTree> SkillTrees { get; set; }
        
        public DbSet<Skill> Skills { get; set; }
    }
}