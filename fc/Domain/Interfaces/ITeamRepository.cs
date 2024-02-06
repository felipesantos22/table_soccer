using fc.Domain.Entities;

namespace fc.Domain.Interfaces;

public interface ITeamRepository
{
    public Task<Team> Create(Team team);
    public Task<List<Team>> Index();
    public Task<Team?> Show(int id);
    public Task<Team> Update(int id, Team team);
    public Task<Team> Destroy(int id);
    public Task<bool> Search(string name);
}