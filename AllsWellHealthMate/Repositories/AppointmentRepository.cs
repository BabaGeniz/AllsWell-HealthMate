using AllsWellHealthMate.Data;
using AllsWellHealthMate.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AllsWellHealthMate.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthMateDbContext _context;

        public AppointmentRepository(HealthMateDbContext context)
        {
            _context = context;
        }

        // Get all appointments
        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments
                .ToList();
        }

        // Get appointment by ID
        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments
                .First(a => a.Id == id);
        }

        // Get appointment by user ID (for patients)
        public IEnumerable<Appointment> GetAppointmentsByUserId(int userId)
        {
            return _context.Appointments
                .Where(a => a.UserId == userId)
                .ToList(); // Assuming PatientId is the user ID
        }

        // Add a new appointment
        public void AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges(); // Save changes to the database
        }

        // Delete an appointment
        public void DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges(); // Save changes to the database
            }
        }
    }
}
