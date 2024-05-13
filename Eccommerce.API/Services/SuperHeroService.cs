using AutoMapper;
using Eccommerce.API.DB;
using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eccommerce.API.Services;

public class SuperHeroService : ISuperHeroService
{
    private readonly DataContext _context;
    public readonly IMapper _mapper;
    public SuperHeroService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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

    public async Task<SuperHeroEntity> AddHero(SuperHero hero)
    {
        var mappedHero = _mapper.Map<SuperHeroEntity>(hero);
        _context.SuperHeroes.Add(mappedHero);
        await _context.SaveChangesAsync();
        return mappedHero;
    }

    public async Task<SuperHeroEntity?> Update(int id, SuperHero request)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero is null)
        {
            return null;
        }

        hero.FirstName = request.FirstName;
        hero.Id = id;
        hero.LastName = request.LastName;
        hero = _mapper.Map<SuperHeroEntity>(hero);
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