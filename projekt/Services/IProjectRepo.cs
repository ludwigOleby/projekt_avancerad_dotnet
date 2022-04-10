using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public interface IProjectRepo<T>
    {

        //Vi vill kunna få ut en lista på alla anställda som jobba med ett specifikt projekt

        Task<IEnumerable<T>> GetEmployeeByProject(int projectID);

        //Vi vill kunna lägga till, uppdatera och ta bort projekt

        Task<T> Add(T newProject);
        Task<T> Update(T project);
        Task<T> Delete(int projectID);
        Task<T> GetSingleProject(int projectID);

    }
}
