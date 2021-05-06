using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }
        [HttpGet("{id}")]
        public Project GetUser(int id)
        {
            return _projectRepository.GetProject(id);
        }

        [HttpPost]
        public Project PostProject([FromBody] Project project)
        {
            return _projectRepository.CreateProject(project);
        }

        [HttpPut("{id}")]
        public Project UpdateProject(int id, [FromBody] Project project)
        {
            project.Id = id;
            return _projectRepository.UpdateProject(project);
        }

        [HttpDelete("{id}")]
        public string DeleteProject(int id)
        {
            return _projectRepository.DeleteProject(id);
        }
    }
}