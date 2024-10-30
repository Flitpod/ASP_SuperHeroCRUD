using M3_SuperHeroCRUD.Data;
using M3_SuperHeroCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace M3_SuperHeroCRUD.Controllers
{
    public class HeroController : Controller
    {
        ISuperHeroRepository repository;

        public HeroController(ISuperHeroRepository repository)
        {
            this.repository = repository;
        }


        public IActionResult Index()
        {
            return View(this.repository.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperHero superHero, IFormFile pictureData)
        {
            using(var stream = pictureData.OpenReadStream())
            {
                byte[] buffer = new byte[pictureData.Length];
                stream.Read(buffer, 0, (int)pictureData.Length);
                string fileName = superHero.Id + "." + pictureData.FileName.Split(".")[1];
                superHero.ImageFileName = fileName;
                System.IO.File.WriteAllBytes(Path.Combine("wwwroot","Images", fileName), buffer);
            }
            if (!ModelState.IsValid)
            {
                return View(superHero);
            }

            this.repository.Create(superHero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            this.repository.Delete(name);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(string name)
        {
            var hero = this.repository.Read(name);
            return View(hero);
        }

        [HttpPost]
        public IActionResult Update(SuperHero superHero)
        {
            if (!ModelState.IsValid)
            {
                return View(superHero);
            }

            this.repository.Update(superHero);
            return RedirectToAction(nameof(Index));
        }
    }
}
