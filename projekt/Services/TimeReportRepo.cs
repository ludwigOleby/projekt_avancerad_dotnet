using Microsoft.EntityFrameworkCore;
using Models;
using projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt.Services
{
    public class TimeReportRepo : ITimeReportRepo<TimeReport>
    {

        private ApiDbContext _TimeRepo;
        public TimeReportRepo(ApiDbContext timeContext)
        {
            _TimeRepo = timeContext;
        }
        public async Task<TimeReport> Add(TimeReport newReport)
        {
            var result = await _TimeRepo.TimeReports.AddAsync(newReport);
            await _TimeRepo.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int reportID)
        {
            var result = await _TimeRepo.TimeReports.FirstOrDefaultAsync(p => p.reportID == reportID);
            if (result != null)
            {
                _TimeRepo.TimeReports.Remove(result);
                await _TimeRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TimeReport>> GetAllReports(int id)
        {
            return await _TimeRepo.TimeReports.Where(p => p.employeeID == id).ToListAsync();
        }

        public async Task<TimeReport> GetSingleTimeReport(int reportID)
        {
            return await _TimeRepo.TimeReports.FirstOrDefaultAsync(x => x.reportID == reportID);
        }

        public async Task<IEnumerable<TimeReport>> GetTimereport(int employeeID, int Week)
        {
            return await _TimeRepo.TimeReports.Where(p => p.employeeID == employeeID).Where(p => p.Week == Week).ToListAsync();
        }

        public async Task<TimeReport> Update(TimeReport timeReport)
        {
            var result = await _TimeRepo.TimeReports.FirstOrDefaultAsync(p => p.reportID == timeReport.reportID);
            if (result != null)
            {
                result.date = timeReport.date;
                result.reportedHours = timeReport.reportedHours;
                result.Week = timeReport.Week;

                await _TimeRepo.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
