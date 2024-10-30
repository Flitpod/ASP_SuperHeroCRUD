using M3_SuperHeroCRUD.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace M3_SuperHeroCRUD.Helpers
{
    public class SuperHeroModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            SuperHero superHero = new SuperHero();
            superHero.Name = bindingContext
                .ValueProvider
                .GetValue("name").FirstValue ?? "";

            superHero.Power = int.Parse(bindingContext
                .ValueProvider
                .GetValue("power")
                .FirstValue ?? "1");

            superHero.IsAlien = bool.Parse(bindingContext
                .ValueProvider
                .GetValue("isalien")
                .FirstValue ?? "false");

            superHero.HeroSide = (HeroSide)Enum.Parse(typeof(HeroSide),bindingContext
                .ValueProvider
                .GetValue("heroside")
                .FirstValue ?? "0");

            var file = bindingContext
                .HttpContext
                .Request
                .Form
                .Files
                .FirstOrDefault();
            if (file != null)
            {
                using (var stream = file.OpenReadStream())
                {
                    byte[] buffer = new byte[file.Length];
                    stream.Read(buffer, 0, (int)file.Length);
                    string fileName = superHero.Id + "." + file.FileName.Split(".")[1];
                    superHero.ImageFileName = fileName;

                    // static file solution
                    // System.IO.File.WriteAllBytes(Path.Combine("wwwroot","Images", fileName), buffer);

                    // database solution
                    superHero.ContentType = file.ContentType;
                    superHero.Data = buffer;
                }
            }

            bindingContext.Result = ModelBindingResult.Success(superHero);
            return Task.CompletedTask;
        }
    }
}
