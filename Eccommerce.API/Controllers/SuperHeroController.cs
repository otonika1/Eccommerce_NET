using Eccommerce.API.Entities;
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
    public async Task<ActionResult<List<SuperHeroEntity>>> GetAllHeroes()
    {
        return Ok(await _superHeroService.GetAllHeroes());
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<List<SuperHeroEntity>>> GetAllHeroesById(int id)
    {
        var result = await _superHeroService.GetAllHeroesById(id);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<SuperHeroEntity>> AddHero(SuperHeroEntity hero)
    {
        var result = await _superHeroService.AddHero(hero);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<SuperHeroEntity>>> Update(int id,SuperHeroEntity request)
    {
        var result = await _superHeroService.Update(id,request);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<SuperHeroEntity>> Delete(int id)
    {
        var result = await _superHeroService.Delete(id);
        if (result is null)
        {
            return NotFound("Hero Not Found");
        }
        return Ok(result);
    }
}