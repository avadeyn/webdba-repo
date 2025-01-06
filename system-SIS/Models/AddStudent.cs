using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
	public class AddStudent
	{
		[MaxLength(100), Required]
		public string Name { get; set; } = "";

		public DateOnly DateofBirth { get; set; }
	}
}
