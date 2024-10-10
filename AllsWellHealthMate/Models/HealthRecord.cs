using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllsWellHealthMate.Models
{
    public class HealthRecord
    { 
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key
        public DateTime DateOfRecord { get; set; }
        public string? MedicalHistory { get; set; }
        public int? HeartRate { get; set; } // Value in bpm
        public int? BloodPressure { get; set; } // Value in mmHg 
        public int? Cholestrol { get; set; } // Value in mg/dL
        public int? GlucoseLevel { get; set; } // Value in mg/dL
        public int? BMI { get;set; }

        public string? Diagnosis { get; set; }
        public string? TreatmentPlan { get; set; }
        public DateTime? ScheduledAppointments { get; set; }
        
        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; } // Foreign key to User who created the appointment

        [ForeignKey("UpdatedByUser")]
        public int? UpdatedBy { get; set; } // Foreign key to User who last updated the appointment
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp of creation
        public DateTime? UpdatedAt { get; set; } = DateTime.Now; // Timestamp of last update
        public bool IsActive { get; set; } = true; // Default to true

        //Navigation Properties
        public ICollection<Prescription>? Prescriptions { get; set; } // List of Prescriptions for this health record
        public ICollection<Allergy>? Allergies { get; set; } // List of Allergies for this health record


    }
}