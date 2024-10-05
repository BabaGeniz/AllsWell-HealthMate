using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AllsWellHealthMate.Models
{
    public class HealthRecord
    { 
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public DateTime DateOfRecord { get; set; }
        public string? MedicalHistory { get; set; }
        public string? Prescriptions { get; set; }
        public string? Allergies { get; set; }
        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public DateTime? ScheduledAppointments { get; set; }
        public int CreatedBy { get; set; } // Foreign Key
        public int UpdatedBy { get; set; } // Foreign Key
        public bool IsActive { get; set; } = true; // Default to true
    }
}