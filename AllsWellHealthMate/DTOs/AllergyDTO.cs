using System.Text.Json.Serialization;


namespace AllsWellHealthMate.DTOs
{
    public class AllergyDTO
    {
        public string AllergyName { get; set; }
        public DateTime? DateIdentified { get; set; } // The date when the allergy was identified (optional)
    }
}