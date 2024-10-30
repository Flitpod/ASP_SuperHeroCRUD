using System.ComponentModel.DataAnnotations;

namespace M3_SuperHeroCRUD.Models
{
    public enum HeroSide
    {
        [Display(Name = "Civil")]
        Civil = 0,

        [Display(Name = "Good")]
        Good = 1,

        [Display(Name = "Bad")]
        Bad = 2
    }

    public class SuperHero
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum hossz 50 karakter lehet!")]
        public string Name { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "Az erő minimum 1 és maximum 10 értékű lehet")]
        public int Power { get; set; }
        
        public bool IsAlien { get; set; }

        [Required]
        public HeroSide HeroSide { get; set; }

        [StringLength(200)]
        public string? ImageFileName { get; set; }

        public string? ContentType { get; set; }

        public byte[]? Data { get; set; }

        public SuperHero()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
