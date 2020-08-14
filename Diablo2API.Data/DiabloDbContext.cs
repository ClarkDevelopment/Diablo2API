using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Diablo2API.Data
{
    public class DiabloDbContext : DbContext
    {
        public DiabloDbContext(DbContextOptions<DiabloDbContext> options) 
            : base(options)
        {
            
        }
    }
}