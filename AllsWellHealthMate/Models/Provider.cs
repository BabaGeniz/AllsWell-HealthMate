namespace AllsWellHealthMate.Models
{
    public class Provider
    {
        public int Id { get; set; } // Primary Key

        public string FirstName { get; set; } // Provider's first name
        public string LastName { get; set; } // Provider's last name
        public string Specialization { get; set; } // Area of specialization (e.g., Cardiologist)
        public string Email { get; set; } // Contact email
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Record creation time
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Record last update time

        public bool IsActive { get; set; } = true; // Indicates whether the provider is currently active
        
        // Navigation properties
        public ICollection<Appointment>? Appointments { get; set; }

    }
}