using Eccommerce.API.Entities;

namespace Eccommerce.API.Services;

public interface ISuperHeroService
{
    Task<List<SuperHeroEntity>> GetAllHeroes();
    Task<SuperHeroEntity> GetAllHeroesById(int id);
    Task<SuperHeroEntity> AddHero(SuperHero hero);
    Task<SuperHeroEntity?> Update(int id, SuperHero request);
    Task<SuperHeroEntity?> Delete(int id);
}