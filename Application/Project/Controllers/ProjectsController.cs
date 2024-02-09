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

        [HttpPost]
        public async Task<ActionResult<Domain.Project.Models.Project>> CreateProject([FromBody] Domain.Project.Models.Project project)
        {
            var createdProject = await _repo.CreateProjectAsync(project);
            return CreatedAtAction(nameof(GetProject), new { id = createdProject.Id }, createdProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Domain.Project.Models.Project>> UpdateProject(int id, [FromBody] Domain.Project.Models.Project project)
        {
            if (id != project.Id)
            {
                return BadRequest("Id in URL and body doesn't match");
            }
            
            var updatedProject = await _repo.UpdateProjectAsync(project);
            return Ok(updatedProject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _repo.DeleteProjectAsync(id);
            return NoContent();
        }
    }
}
