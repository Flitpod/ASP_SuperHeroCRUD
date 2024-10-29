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
        public IActionResult Create(SuperHero superHero)
        {
            this.repository.Create(superHero);
            return RedirectToAction(nameof(Index));
        }
    }
}
