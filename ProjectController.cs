using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stitch_BackEnd
{
    [ApiController]
    [Route("projects")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectController()
        {
            _projectRepository = new ProjectRepository();
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _projectRepository.GetAllProjects();
        }
        [HttpGet("{id}")]
        public async Task<Project> GetUser(int id)
        {
            return await _projectRepository.GetProject(id);
        }

        [HttpPost]
        public async Task<Project> PostProject([FromBody] Project project)
        {
            return await _projectRepository.CreateProject(project);
        }

        [HttpPut("{id}")]
        public async Task<Project> UpdateProject(int id, [FromBody] Project project)
        {
            project.Id = id;
            return await _projectRepository.UpdateProject(project);
        }

        [HttpDelete("{id}")]
        public async Task<Project> DeleteProject(int id)
        {
            return await _projectRepository.DeleteProject(id);
        }
    }
}