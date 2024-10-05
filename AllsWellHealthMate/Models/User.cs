using System.ComponentModel.DataAnnotations;

namespace AllsWellHealthMate.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        public int Height { get; set; }
        public bool IsActive { get; set; } = true; // Default to true
        
        // Navigation properties for foreign keys
        public HealthRecord? HealthRecord { get; set; }
        public ICollection<Appointment>? Appointments { get; set; } 
    }
}