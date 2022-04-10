using Microsoft.EntityFrameworkCore;
using Models;
using projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public class ProjectRepo : IProjectRepo<Projects>
    {

        private ApiDbContext _ProjectRepo;
        public ProjectRepo(ApiDbContext projectContext)
        {
            _ProjectRepo = projectContext;
        }

        public async Task<Projects> Add(Projects newProject)
        {
            var result = await _ProjectRepo.Projects.AddAsync(newProject);
            await _ProjectRepo.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Projects> Delete(int projectID)
        {
            var result = await _ProjectRepo.Projects.FirstOrDefaultAsync(p => p.projectID == projectID);
            if (result != null)
            {
                _ProjectRepo.Projects.Remove(result);
                await _ProjectRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Projects>> GetEmployeeByProject(int projectID)
        {
            return await _ProjectRepo.Projects.Where(p => p.projectID == projectID).ToListAsync();
        }

        public async Task<Projects> GetSingleProject(int projectID)
        {
            return await _ProjectRepo.Projects.FirstOrDefaultAsync(x => x.projectID == projectID);
        }

        public async Task<Projects> Update(Projects project)
        {

            var result = await _ProjectRepo.Projects.FirstOrDefaultAsync(p => p.projectID == project.projectID);
            if (result != null)
            {
                result.projectName = project.projectName;
                result.employeeID = project.employeeID;

                await _ProjectRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
