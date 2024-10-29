using System.ComponentModel.DataAnnotations;

namespace M3_SuperHeroCRUD.Models
{
    public enum HeroSide
    {
        Civil = 0, Good, Bad 
    }

    public class SuperHero
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1,10)]
        public int Power { get; set; }
    
        public bool IsAlien { get; set; }

        [Required]
        public HeroSide HeroSide { get; set; }
    }
}
