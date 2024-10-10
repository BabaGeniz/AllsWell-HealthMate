using AllsWellHealthMate.Models;
using System.ComponentModel.DataAnnotations;

namespace AllsWellHealthMate.DTOs
{
    public class HealthRecordDTO
    {
        public int UserId { get; set; } // Foreign Key
        public DateTime DateOfRecord { get; set; } =DateTime.Now;
        public string? MedicalHistory { get; set; }
        public int? HeartRate { get; set; } // Value in bpm
        public int? BloodPressure { get; set; } // Value in mmHg 
        public int? Cholestrol { get; set; } // Value in mg/dL
        public int? GlucoseLevel { get; set; } // Value in mg/dL
        public int? BMI { get; set; }

        public string? Diagnosis { get; set; } = "No available Diagnosis";
        public string? TreatmentPlan { get; set; } = "No available Treatment Plan";
        public DateTime? ScheduledAppointments { get; set; }
        
        //Navigation Properties
        public ICollection<PrescriptionDTO>? Prescriptions { get; set; } // List of Prescriptions for this health record
        public ICollection<AllergyDTO>? Allergies { get; set; } // List of Allergies for this health record
    }
}