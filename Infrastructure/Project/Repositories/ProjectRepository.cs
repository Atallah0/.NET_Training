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
    }
}