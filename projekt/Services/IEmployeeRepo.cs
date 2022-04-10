using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public interface IEmployeeRepo<T>
    {
        //Vi vill kunna få ut en lista med alla anställda i systemet
        Task<IEnumerable<T>> GetEmployees();

        //Vi vill kunna lägga till, uppdatera och ta bort anställda.
        Task<T> GetSingleEmployee(int employeeID);

        Task<T> Add(T newEmployee);
        Task<T> Update(T Employee);
        Task<T> Delete(int employeeID);




    }
}
