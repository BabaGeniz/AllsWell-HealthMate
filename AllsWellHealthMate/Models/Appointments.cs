using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllsWellHealthMate.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [ForeignKey("Patient")]
        public int UserId { get; set; } // Foreign Key to Users (Patients)


        [ForeignKey("Provider")]
        public int ProviderId { get; set; } // Foreign Key to Providers

        [Required]
        public DateTime AppointmentDate { get; set; } // Date and time of the appointment

        public string AppointmentType { get; set; } // Type of the appointment (e.g., "Consultation", "Follow-up")
        public string Status { get; set; } = "Scheduled"; // Appointment status (e.g., "Scheduled", "Completed", "Cancelled")
        public string Location { get; set; } // Physical or virtual location for the appointment

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; } // Foreign key to User who created the appointment

        [ForeignKey("UpdatedByUser")]
        public int? UpdatedBy { get; set; } // Foreign key to User who last updated the appointment

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp of creation
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Timestamp of last update
    }
}
