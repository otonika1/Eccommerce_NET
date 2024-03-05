using Eccommerce.API.Entities;

namespace Eccommerce.API.Services;

public interface ISuperHeroService
{
    Task<List<SuperHeroEntity>> GetAllHeroes();
    Task<SuperHeroEntity> GetAllHeroesById(int id);
    Task<SuperHeroEntity> AddHero(SuperHeroEntity hero);
    Task<SuperHeroEntity?> Update(int id, SuperHeroEntity request);
    Task<SuperHeroEntity?> Delete(int id);
}