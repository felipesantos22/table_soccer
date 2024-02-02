using fc.Domain.Entities;
using fc.Infra.Respository;
using Microsoft.AspNetCore.Mvc;

namespace fc.Controllers;

[Route("api/v1/team")]
[ApiController]
public class TeamController: ControllerBase
{
    private readonly TeamRepository _teamRepository;

    public TeamController(TeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Team>> Create([FromBody] Team team)
    {
        var newTeam = await _teamRepository.Create(team);
        return Ok(newTeam);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Team>>> Index()
    {
        var teams = await _teamRepository.Index();
        return Ok(teams);
    }
}