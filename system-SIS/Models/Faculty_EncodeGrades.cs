using System.ComponentModel.DataAnnotations;

namespace system_SIS.Models
{
	public class EncodeGrades
	{
		[Key]
		public int StudentId { get; set; }

		[MaxLength(100), Required]
		public string Name { get; set; } = "";

		public DateOnly DateofBirth { get; set; }

	}
}
