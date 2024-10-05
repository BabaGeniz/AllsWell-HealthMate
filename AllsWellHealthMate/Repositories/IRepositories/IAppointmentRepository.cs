
using System.Collections.Generic;
using AllsWellHealthMate.Models;

namespace AllsWellHealthMate.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointments();
        Appointment GetAppointmentById(int id);
        IEnumerable<Appointment> GetAppointmentsByUserId(int userId);
        void AddAppointment(Appointment appointment);
        void DeleteAppointment(int id);
    }
}