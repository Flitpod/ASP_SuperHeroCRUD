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
            var heroesSameName = db.SuperHeroes.FirstOrDefault(sh  => sh.Name == superHero.Name);
            if (heroesSameName != null)
            {
                throw new ArgumentException("Hero with this name alredy exists!");
            }
            this.db.SuperHeroes.Add(superHero);
            this.db.SaveChanges();
        }
        public IEnumerable<SuperHero> Read() => this.db.SuperHeroes;
        public SuperHero? Read(string name)
        {
            return this.db.SuperHeroes.FirstOrDefault(sh => sh.Name == name);
        }
        public SuperHero? ReadFromId(string id)
        {
            return this.db.SuperHeroes.FirstOrDefault(sh => sh.Id == id);
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
                .GetProperties()
                .Where(p => p.GetValue(superHero) != null && p.Name != "Id");

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
