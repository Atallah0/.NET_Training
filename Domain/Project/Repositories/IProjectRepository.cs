namespace Domain.Project.Repositories
{
    public interface IProjectRepository
    {
        Task<Models.Project> GetProjectByIdAsync(int id);
        Task<IReadOnlyList<Models.Project>> GetProjectsAsync();
    }
}