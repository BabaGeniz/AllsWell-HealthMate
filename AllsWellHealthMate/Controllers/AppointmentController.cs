using Microsoft.AspNetCore.Mvc;
using AllsWellHealthMate.Models;
using AllsWellHealthMate.DTOs;
using AllsWellHealthMate.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllsWellHealthMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        // Constructor to inject the service
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        [Route("GetAllAppointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsByUserId(int userId)
        {
            var appointments = await _appointmentService.GetAppointmentsByUserId(userId);
            if (appointments == null || !appointments.Any())
            {
                return NotFound(); // Return 404 if no appointments are found for the user
            }

            return Ok(appointments);
        }

        // Create Appointment
        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] AppointmentDTO appointmentDTO)
        {
            var createdAppointment = await _appointmentService.CreateAppointment(appointmentDTO);
            return CreatedAtAction(nameof(GetAppointment), new { id = createdAppointment.Id }, createdAppointment);
        }

        // DELETE Appointment
        [HttpDelete("{id}")]
        public IActionResult DeleteAppointment(int id)
        {
            _appointmentService.DeleteAppointment(id);
            return NoContent();
        }


    }
}