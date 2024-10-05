using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllsWellHealthMate.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [ForeignKey("HealthRecord")]
        public int HealthRecordId { get; set; } // Foreign Key to HealthRecord

        public string DrugName { get; set; } // Name of the prescribed drug
        public string Dosage { get; set; } // Dosage instructions
        public DateTime DatePrescribed { get; set; } // Date when the prescription was written
        public string PrescribingDoctor { get; set; } // Name or ID of the prescribing doctor

        public bool IsActive { get; set; } = true; // Whether the prescription is currently active (e.g., still valid)
    }
}
