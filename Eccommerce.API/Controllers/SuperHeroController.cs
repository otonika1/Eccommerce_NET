using Eccommerce.API.Model;
using Eccommerce.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eccommerce.API.Controllers;
[Route(("api/[controller]"))]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;
    public SuperHeroController(ISuperHeroService superHeroService)
    {
        this._superHeroService = superHeroService;
    }
    [HttpGet("all")]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
    {
        return Ok(_superHeroService.GetAllHeroes());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<SuperHero>>> GetAllHeroesById(int id)
    {
        var result = _superHeroService.GetAllHeroesById(id);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
    {
        var result = _superHeroService.AddHero(hero);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Update(int id,SuperHero request)
    {
        var result = _superHeroService.Update(id,request);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<SuperHero>> Delete(int id)
    {
        var result = _superHeroService.Delete(id);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }
}