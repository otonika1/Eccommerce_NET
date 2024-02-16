namespace Eccommerce.API.Services;

public interface ISuperHeroService
{
    List<SuperHero> GetAllHeroes();
    SuperHero GetAllHeroesById(int id);
    SuperHero AddHero(SuperHero hero);
    SuperHero? Update(int id, SuperHero request);
    SuperHero? Delete(int id);
}