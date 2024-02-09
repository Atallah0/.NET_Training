using Domain.Project.Repositories;
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
        private readonly IProjectRepository _repo;

        public ProjectsController(IProjectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Domain.Project.Models.Project>>> GetProjects()
        {
            var projects = await _repo.GetProjectsAsync();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Project.Models.Project>> GetProject(int id)
        {
            return await _repo.GetProjectByIdAsync(id);
        }
    }
}