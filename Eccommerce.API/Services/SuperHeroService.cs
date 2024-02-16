namespace Eccommerce.API.Services;

public class SuperHeroService : ISuperHeroService
{
    private static List<SuperHero> superHeroes = new List<SuperHero>
    {
        new SuperHero 
        {
            Id = 1,
            FirstName = "oto",
            LastName = "avlokhashvili"
        },
        new SuperHero
        {
            Id = 2,
            FirstName = "varsqen",
            LastName = "avlokhashvili"
        }
    };
    public List<SuperHero> GetAllHeroes()
    {
        return superHeroes;
    }

    public SuperHero GetAllHeroesById(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);
        if (hero is null)
        {
            return null;
        }
        return hero;
    }

    public SuperHero AddHero(SuperHero hero)
    {
        superHeroes.Add(hero);
        return hero;
    }

    public SuperHero? Update(int id, SuperHero request)
    {
        var hero = superHeroes.Find(x => x.Id == id);
        if (hero is null)
        {
            return null;
        }

        hero.FirstName = request.FirstName;
        hero.Id = request.Id;
        hero.LastName = request.LastName;
        return hero;
    }

    public SuperHero? Delete(int id)
    {
        var hero = superHeroes.Find(x => x.Id == id);
        if (hero is null)
        {
            return null;
        }

        superHeroes.Remove(hero);
        return hero;
    }
}