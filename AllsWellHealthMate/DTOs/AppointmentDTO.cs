using System;

namespace AllsWellHealthMate.DTOs
{
    public class AppointmentDTO
    {
        public int UserId { get; set; } // Foreign Key to Users (Patients)
        public int ProviderId { get; set; } // Foreign Key to Providers
        public DateTime AppointmentDate { get; set; } // Date and time of the appointment
        public string AppointmentType { get; set; } // Type of the appointment (e.g., "Consultation", "Follow-up")
        public string Status { get; set; } = "Scheduled"; // Appointment status (e.g., "Scheduled", "Completed", "Cancelled")
        public string Reason { get; set; } // Reason for appointment
    }
}