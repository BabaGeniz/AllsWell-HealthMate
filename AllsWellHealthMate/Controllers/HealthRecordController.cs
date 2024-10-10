using Microsoft.AspNetCore.Mvc;
using AllsWellHealthMate.Services;
using AllsWellHealthMate.DTOs;
using AllsWellHealthMate.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllsWellHealthMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthRecordController : ControllerBase
    {
        private readonly IHealthRecordService _healthRecordService;

        public HealthRecordController(IHealthRecordService healthRecordService)
        {
            _healthRecordService = healthRecordService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HealthRecord>> GetAllHealthRecords()
        {
            var records = _healthRecordService.GetAllHealthRecords();
            return Ok(records);
        }

        // GET: api/HealthRecord/{id}
        [HttpGet("{id}")]
        public ActionResult<HealthRecord> GetHealthRecordById(int id)
        {
            var record = _healthRecordService.GetHealthRecordById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        // GET: api/HealthRecord/User/{userId}
        [HttpGet("User/{userId}")]
        public ActionResult<HealthRecord> GetHealthRecordByUserId(int userId)
        {
            var record = _healthRecordService.GetHealthRecordByUserId(userId);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        [Route("CreateHealthRecord")]
        public IActionResult CreateHealthRecord([FromBody] HealthRecordDTO healthRecordDTO)
        {
            var newRecord = _healthRecordService.CreateHealthRecord(healthRecordDTO);
            return CreatedAtAction(nameof(GetHealthRecordById), new { id = newRecord.Id }, newRecord);
        }

        [HttpPost]
        [Route("UpdateHealthRecord")]
        public IActionResult UpdateHealthRecord([FromBody] HealthRecordDTO healthRecordDTO)
        {
            var updatedRecord = _healthRecordService.UpdateHealthRecord(healthRecordDTO);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/HealthRecord/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteHealthRecord(int id)
        {
            var record = _healthRecordService.GetHealthRecordById(id);
            if (record == null)
            {
                return NotFound();
            }

            _healthRecordService.DeleteHealthRecord(id);
            return NoContent();
        }
    }
}
