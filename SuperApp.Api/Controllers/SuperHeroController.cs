using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperApp.Application.Heroes.Commands.Delete;
using SuperApp.Application.Heroes.Commands.Insert;
using SuperApp.Application.Heroes.Commands.Update;
using SuperApp.Application.Heroes.Queries;

namespace SuperApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SuperHeroController : Controller
{
    private readonly IGetAllHeroQuery _getAllHeroQuery;
    private readonly IGetHero _getHero;
    private readonly IInsertHeroCommand _insertHeroCommand;
    private readonly IUpdateHeroCommand _updateHeroCommand;
    private readonly IDeleteHeroCommand _deleteHeroCommand;
    
    public SuperHeroController(
        IGetAllHeroQuery getAllHeroQuery, 
        IGetHero getHero, 
        IInsertHeroCommand insertHeroCommand, 
        IUpdateHeroCommand updateHeroCommand,
        IDeleteHeroCommand deleteHeroCommand)
    {
        _getAllHeroQuery = getAllHeroQuery;
        _getHero = getHero;
        _insertHeroCommand = insertHeroCommand;
        _updateHeroCommand = updateHeroCommand;
        _deleteHeroCommand = deleteHeroCommand;
    }
    
    [HttpGet]
    public Task<ActionResult<List<SuperHeroDTO>>> GetAllHeroes()
    {
        return Task.FromResult<ActionResult<List<SuperHeroDTO>>>(Ok(_getAllHeroQuery.Execute()));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHeroDTO>> GetHero(int id)
    {
        try
        {
            return await Task.FromResult<ActionResult<SuperHeroDTO>>(Ok(_getHero.Execute(id)));
        }
        catch (Exception e)
        {
            if (e.Message == "NotFound")
            {
                return NotFound("Hero Not Found");
            }
            else
            {
                throw;
            }
        }
    }

    [HttpPost]
    public ActionResult<SuperHeroDTO> InsertHero(InsertHeroDTO insertHeroDto)
    {
        var superHeroDto = _insertHeroCommand.Execute(insertHeroDto);

        return Ok(superHeroDto);
    }
    
    [HttpPut]
    public ActionResult<SuperHeroDTO> InsertHero(SuperHeroDTO updateSuperHeroDto)
    {
        var superHeroDto = _updateHeroCommand.Execute(updateSuperHeroDto);

        return Ok(superHeroDto);
    }
    
    [HttpDelete]
    public ActionResult<List<SuperHeroDTO>> DeleteHero(int id)
    {
        _deleteHeroCommand.Execute(id);

        return Ok(_getAllHeroQuery.Execute());
    }
}
