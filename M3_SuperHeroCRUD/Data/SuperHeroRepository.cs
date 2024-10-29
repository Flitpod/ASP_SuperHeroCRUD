using M3_SuperHeroCRUD.Models;

namespace M3_SuperHeroCRUD.Data
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        // fields
        List<SuperHero> superHeroes;

        // ctor
        public SuperHeroRepository()
        {
            this.superHeroes = new List<SuperHero>();
        }

        // methods
        public void Create(SuperHero superHero) => superHeroes.Add(superHero);

        public IEnumerable<SuperHero> Read() => this.superHeroes;
        public SuperHero Read(string name)
        {
            return this.superHeroes.FirstOrDefault(sh => sh.Name == name);
        }

        public void Update(SuperHero superHero)
        {
            var oldHero = Read(superHero.Name);

            if (oldHero == null)
            {
                return;
            }

            var props = superHero
                .GetType()
                .GetProperties();

            foreach (var prop in props)
            {
                prop.SetValue(oldHero, prop.GetValue(superHero));
            }
        }

        public bool Delete(string name)
        {
            var hero = Read(name);

            if (hero == null)
            {
                return false;
            }

            return superHeroes.Remove(hero);
        }
    }
}
