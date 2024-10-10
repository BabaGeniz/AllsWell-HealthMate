
using System.Text.Json.Serialization;

namespace AllsWellHealthMate.DTOs
{
    public class PrescriptionDTO
    {
        public string DrugName { get; set; } // Name of the prescribed drug
        public string Dosage { get; set; } // Dosage instructions
        public DateTime DatePrescribed { get; set; } // Date when the prescription was written
        public string? PrescribingDoctor { get; set; } // Name or ID of the prescribing doctor
        public int ProviderId { get; set; }
    }
}