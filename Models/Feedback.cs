using DAW.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW.Models
{
	public class Feedback
	{
		public int Id { get; set; }

		[Required]
		public int Scor { get; set; }

		[StringLength(500)]
		public string Comentariu { get; set; }

		// Relație cu Stire
		public int StireId { get; set; }
		public Stiri Stire { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}
