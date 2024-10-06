using System.ComponentModel.DataAnnotations;

namespace AllsWellHealthMate.DTOs
{
	public class UserCreateDTO
	{
		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public int UserRole { get; set; }
	}
	public class UserDTO
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int Age { get; set; }
		public int Height { get; set; } // In cm
	}
    public class ProviderDTO
    {	
        public string Specialization { get; set; } // Area of specialization (e.g., Cardiologist)
        public string HospitalAffiliation { get; set; }
    }
    public class UserWrapperDTO
    {
        public UserCreateDTO userCreateDTO { get; set; }
        public ProviderDTO providerDTO { get; set; }
    }
}