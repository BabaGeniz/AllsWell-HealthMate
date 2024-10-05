using AllsWellHealthMate.Models;
using AllsWellHealthMate.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<Appointment> GetAppointmentById(int id);
    Task<IEnumerable<Appointment>> GetAppointmentsByUserId(int userId);
    Task<Appointment> CreateAppointment(AppointmentDTO appointmentDTO);
    Task DeleteAppointment(int id);
}