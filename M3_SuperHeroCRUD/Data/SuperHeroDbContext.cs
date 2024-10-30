using M3_SuperHeroCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace M3_SuperHeroCRUD.Data
{
    public class SuperHeroDbContext:DbContext
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }

        public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> options)
            :base(options)
        {
            
        }
    }
}
