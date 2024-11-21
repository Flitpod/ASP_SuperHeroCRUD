using M3_SuperHeroCRUD.Data;
using M3_SuperHeroCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace M3_SuperHeroCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController: ControllerBase
    {
        ISuperHeroRepository _superHeroRepository;

        public ApiController(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;
        }

        [HttpGet]
        public IEnumerable<SuperHero> GetHeroes()
        {
            return _superHeroRepository.Read();
        }
    }
}
