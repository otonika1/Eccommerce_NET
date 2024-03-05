using Eccommerce.API.DB;
using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eccommerce.API.Services;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;
    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<SuperHeroEntity>> GetAllHeroes()
    {
        var heroes = await _context.SuperHeroes.ToListAsync();
        return heroes;
    }

    public async Task<SuperHeroEntity> GetAllHeroesById(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }
        return hero;
    }

    public async Task<SuperHeroEntity> AddHero(SuperHeroEntity hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        return hero;
    }

    public async Task<SuperHeroEntity?> Update(int id, SuperHeroEntity request)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        hero.FirstName = request.FirstName;
        hero.Id = request.Id;
        hero.LastName = request.LastName;

        await _context.SaveChangesAsync();
        return hero;
    }

    public async Task<SuperHeroEntity?> Delete(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        return hero;
    }
}