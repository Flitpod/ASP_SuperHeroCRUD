using M3_SuperHeroCRUD.Models;

namespace M3_SuperHeroCRUD.Data
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        // fields
        private SuperHeroDbContext db;

        // ctor
        public SuperHeroRepository(SuperHeroDbContext db)
        {
            this.db = db;
        }

        // methods
        public void Create(SuperHero superHero)
        {
            this.db.SuperHeroes.Add(superHero);
            this.db.SaveChanges();
        }
        public IEnumerable<SuperHero> Read() => this.db.SuperHeroes;
        public SuperHero Read(string name)
        {
            return this.db.SuperHeroes.FirstOrDefault(sh => sh.Name == name);
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

            this.db.SaveChanges();
        }

        public void Delete(string name)
        {
            var hero = Read(name);

            if (hero == null)
            {
                return;
            }

            this.db.SuperHeroes.Remove(hero);
            this.db.SaveChanges();
        }
    }
}
