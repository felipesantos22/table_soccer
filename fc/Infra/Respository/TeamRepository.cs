using fc.Domain.Entities;
using fc.Domain.Interfaces;
using fc.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace fc.Infra.Respository;

public class TeamRepository: ITeamRepository
{
    private readonly DataContext _dataContext;

    public TeamRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Team> Create(Team team)
    {
        await _dataContext.Teams.AddAsync(team);
        await _dataContext.SaveChangesAsync();
        return team;
    }

    public async Task<List<Team>> Index()
    {
        var teams = await _dataContext.Teams.ToListAsync();
        return teams;
    }

    public async Task<Team?> Show(int id)
    {
        var team = await _dataContext.Teams.FindAsync(id);
        return team;
    }

    public async Task<Team> Update(int id, Team team)
    {
        var teamUpdate = await _dataContext.Teams.FirstOrDefaultAsync(c => c.id == id);
        teamUpdate!.teamName = team.teamName;
        await _dataContext.SaveChangesAsync();
        return teamUpdate;
    }

    public Task<Team> Destroy(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Team> Search(string name)
    {
        throw new NotImplementedException();
    }
}