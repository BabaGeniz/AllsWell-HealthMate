using AllsWellHealthMate.Models;
using AllsWellHealthMate.Data;
using AllsWellHealthMate.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllsWellHealthMate.Repositories;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointments()
    {
        return _appointmentRepository.GetAllAppointments();
    }

    public async Task<Appointment> GetAppointmentById(int id)
    {
        return _appointmentRepository.GetAppointmentById(id);
    }
    public async Task<IEnumerable<Appointment>> GetAppointmentsByUserId(int userId)
    {
        return _appointmentRepository.GetAppointmentsByUserId(userId);
    }

    public async Task<Appointment> CreateAppointment(AppointmentDTO appointmentDTO)
    {
        // Mapping of DTO properties to regular properties
        var appointment = new Appointment
        {
            UserId = appointmentDTO.UserId,
            ProviderId = appointmentDTO.ProviderId,
            AppointmentDate = appointmentDTO.AppointmentDate,
            AppointmentType = appointmentDTO.AppointmentType,
            Status = appointmentDTO.Status,
            Reason  = appointmentDTO.Reason,
            CreatedBy = 0,
            UpdatedBy = 0,
            UpdatedAt = DateTime.MaxValue,
            CreatedAt = DateTime.UtcNow,
        };

        _appointmentRepository.AddAppointment(appointment);
        return appointment;
    }

    public async Task DeleteAppointment(int id)
    {
        _appointmentRepository.DeleteAppointment(id);
    }
}

