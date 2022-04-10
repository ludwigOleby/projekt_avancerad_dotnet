using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public interface ITimeReportRepo<T>
    {
        //Vi vill kunna hämta ut detaljerad information om en specifik anställd och dennas tidsrapporter

        Task<T> GetSingleTimeReport(int employeeID);

        // Alla tidsrapporter
        Task<IEnumerable<T>> GetAllReports(int id);

        //Vi vill kunna få ut hur många timmar en specifik anställd jobbat en specifik vecka (ex antal timmar vecka 25)

        Task<IEnumerable<T>> GetTimereport(int employeeID, int Week);

        //Vi vill kunna lägga till, uppdatera och ta bort specifika tids rapporter

        Task<T> Add(T newReport);
        Task<T> Update(T timeReport);
        Task<T> Delete(int reportID);
       


    }
}
