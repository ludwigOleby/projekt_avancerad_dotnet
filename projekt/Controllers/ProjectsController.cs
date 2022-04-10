using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using projekt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private IProjectRepo<Projects> _projects;
        public ProjectsController(IProjectRepo<Projects> Projects)
        {
            _projects = Projects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetEmployeeByProject(int projectID)
        {
            var result = await _projects.GetSingleProject(projectID);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }


        [HttpPost]
        public async Task<ActionResult<Projects>> Add(Projects newProject)
        {
            try
            {
                if (newProject == null)
                {
                    return BadRequest();
                }
                var CreatedProject = await _projects.Add(newProject);
                return CreatedAtAction(nameof(GetSingleProject), new { id = CreatedProject.projectID }, CreatedProject);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Projects>> Update(int id, Projects newProject)
        {
            try
            {
                if (id != newProject.projectID)
                {
                    return BadRequest("Employee id does not match!");
                }
                var projectToUpdate = await _projects.GetSingleProject(id);
                if (projectToUpdate == null)
                {
                    return NotFound($"Employee with {id} not found...");
                }
                return await _projects.Update(newProject);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projects>> Delete(int id)
        {
            try
            {
                var projectToDelete = await _projects.GetSingleProject(id);
                if (projectToDelete == null)
                {
                    return NotFound($"Project with {id} not found...");
                }
                return await _projects.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id:int}")] 
        public async Task<ActionResult<Projects>> GetSingleProject(int id)
        {
            var result = await _projects.GetSingleProject(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

    }
}
