using M3_SuperHeroCRUD.Data;
using M3_SuperHeroCRUD.Models;
using Microsoft.AspNetCore.Diagnostics;
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

        [OutputCache(Duration = 5, VaryByParam = "none")]
        public IActionResult Index()
        {
            return View(this.repository.Read());
        }

        [OutputCache(Duration = 5, VaryByParam = "none")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperHero superHero)
        {
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

        [HttpGet]
        public IActionResult GetImage(string id)
        {
            var superHero = this.repository.ReadFromId(id);
            if (superHero?.ContentType?.Length > 0)
            {
                return new FileContentResult(superHero.Data, superHero.ContentType);
            }
            return BadRequest();
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var message = exceptionHandlerPathFeature.Error.Message;

            return View("Error", message);
        }
    }
}
