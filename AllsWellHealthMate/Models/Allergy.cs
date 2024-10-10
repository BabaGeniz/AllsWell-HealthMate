using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllsWellHealthMate.Models
{
    public class Allergy
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [ForeignKey("HealthRecord")]
        public int HealthRecordId { get; set; } // Foreign Key to HealthRecord
        public string AllergyName { get; set; }
        public DateTime? DateIdentified { get; set; } // The date when the allergy was identified (optional)
        
        // Navigation property
        public HealthRecord HealthRecord { get; set; }

    }
}