using Infrastructure.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Domain.Project.Models;
namespace Application.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly LearningContext _context;

        public ProjectsController(LearningContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Project.Models.Project>>> GetProjects()
        {
            var projects = await _context.Projects.ToListAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Project.Models.Project>> GetProject(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
    }
}