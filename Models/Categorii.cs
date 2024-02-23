using DAW.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAW.Models
{
	public class Categorii
	{
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string Nume { get; set; }

		// Relație cu Stiri
		public ICollection<Stiri> Stiri { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}
