using M3_SuperHeroCRUD.Models;

namespace M3_SuperHeroCRUD.Data
{
    public interface ISuperHeroRepository
    {
        void Create(SuperHero superHero);
        void Delete(string name);
        IEnumerable<SuperHero> Read();
        SuperHero Read(string name);
        void Update(SuperHero superHero);
    }
}