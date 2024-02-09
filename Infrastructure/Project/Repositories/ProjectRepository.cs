using Domain.Project.Repositories;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Project.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly LearningContext _context;
        public ProjectRepository(LearningContext context)
        {
            _context = context;
        }

        public async Task<Domain.Project.Models.Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<IReadOnlyList<Domain.Project.Models.Project>> GetProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Domain.Project.Models.Project> CreateProjectAsync(Domain.Project.Models.Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Domain.Project.Models.Project> UpdateProjectAsync(Domain.Project.Models.Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var project = await GetProjectByIdAsync(id);
            if (project == null)
            {
                throw new InvalidOperationException("Project not found");
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}