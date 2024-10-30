using M3_SuperHeroCRUD.Helpers;
using Microsoft.AspNetCore.Mvc;
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

    [ModelBinder(BinderType = typeof(SuperHeroModelBinder))]
    public class SuperHero
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum hossz 50 karakter lehet!")]
        [ShowTable]
        public string Name { get; set; }

        [Required]
        [Range(1,10, ErrorMessage = "Az erő minimum 1 és maximum 10 értékű lehet")]
        [ShowTable]
        public int Power { get; set; }
        
        [ShowTable]
        public bool IsAlien { get; set; }

        [Required]
        [ShowTable]
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
