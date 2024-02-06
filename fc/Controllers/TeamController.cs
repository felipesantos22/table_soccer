using fc.Domain.Entities;
using fc.Domain.Interfaces;
using fc.Infra.Respository;
using Microsoft.AspNetCore.Mvc;

namespace fc.Controllers;

[Route("api/v1/team")]
[ApiController]
public class TeamController: ControllerBase
{
    private readonly ITeamRepository _teamRepository;

    public TeamController(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult<Team>> Create([FromBody] Team team)
    {
        var existsTeam = await _teamRepository.Search(team.teamName);
        if (existsTeam)
        {
            return NotFound(new { message = "Team exists in database" });
        }
        var newTeam = await _teamRepository.Create(team);
        return Ok(newTeam);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Team>>> Index()
    {
        var teams = await _teamRepository.Index();
        return Ok(teams);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Team>>> Show(int id)
    {
        var team = await _teamRepository.Show(id);
        if (team == null)
        {
            return NotFound(new { message = "Team not found" });
        }
        return Ok(team);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Team>> Update(int id, [FromBody] Team team)
    {
        var updateTeam = await _teamRepository.Show(id);
        if (updateTeam == null) return NotFound(new { message = "Team not found" });
        await _teamRepository.Update(id, team);
        return Ok(new { message = "Team Updated" });
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Team>> Destroy(int id)
    {
        var updateTeam = await _teamRepository.Show(id);
        if (updateTeam == null) return NotFound(new { message = "Team not found" });
        await _teamRepository.Destroy(id);
        return Ok(new { message = "Team deleted" });
    }
    
    [HttpGet("search")]
    public async Task<ActionResult<List<Team>>> Search([FromQuery] string name)
    {
        var team = await _teamRepository.Search(name);
        if (!team) return NotFound(new { message = "Team not found" });
        return Ok(team);
    }
}