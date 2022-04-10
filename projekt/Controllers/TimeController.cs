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
    public class TimeController : ControllerBase
    {
        private ITimeReportRepo<TimeReport> _TimeRepo;
        public TimeController(ITimeReportRepo<TimeReport> TimeReport)
        {
            _TimeRepo = TimeReport;
        }

        [HttpPost]
        public async Task<ActionResult<TimeReport>> Add(TimeReport newReport)
        {
            try
            {
                if (newReport == null)
                {
                    return BadRequest();
                }
                var CreatedReport = await _TimeRepo.Add(newReport);
                return CreatedAtAction(nameof(GetSingleTimeReport), new { id = newReport.reportID }, newReport);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TimeReport>> Delete(int id)
        {
            try
            {
                var reportToDelete = await _TimeRepo.GetSingleTimeReport(id);
                if (reportToDelete == null)
                {
                    return NotFound($"Project with {id} not found...");
                }
                return await _TimeRepo.Delete(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id:int}")]
        [Route("{id}/single")]
        public async Task<ActionResult<TimeReport>> GetSingleTimeReport(int id)
        {
            var result = await _TimeRepo.GetSingleTimeReport(id);
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
        [HttpGet("{id:int}")]
        [Route("{id}/all")]
        public async Task<ActionResult<TimeReport>> GetAllReports(int id)
        {
            var result = await _TimeRepo.GetAllReports(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(await _TimeRepo.GetAllReports(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpGet("{id:int}/{Week:int}")]
        public async Task<ActionResult<TimeReport>> GetTimereport(int id, int Week)
        {
            var result = await _TimeRepo.GetTimereport(id,Week);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(await _TimeRepo.GetTimereport(id, Week)); //TODO Test this, should just return "results" in the other methods
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TimeReport>> Update(int id, TimeReport newTimeReport)
        {
            try
            {
                if (id != newTimeReport.reportID)
                {
                    return BadRequest("Report id does not match!");
                }
                var reportToUpdate = await _TimeRepo.GetSingleTimeReport(id);
                if (reportToUpdate == null)
                {
                    return NotFound($"report with {id} not found...");
                }
                return await _TimeRepo.Update(newTimeReport);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }

    }
}
