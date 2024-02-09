namespace Domain.Project.Repositories
{
    public interface IProjectRepository
    {
        Task<Models.Project> GetProjectByIdAsync(int id);
        Task<IReadOnlyList<Models.Project>> GetProjectsAsync();
        Task<Models.Project> CreateProjectAsync(Models.Project project);
        Task<Models.Project> UpdateProjectAsync(Models.Project project);
        Task DeleteProjectAsync(int id);
    }
}