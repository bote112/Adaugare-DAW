using DAW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAW.Models
{
	public class Stiri
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Titlu { get; set; }

		[Required]
		public string Continut { get; set; }

		public DateTime DataPublicarii { get; set; }

		// Relație cu Categorii
		public int CategoriiId { get; set; }
		public Categorii Categorie { get; set; }

		// Relație cu Feedbackuri
		public ICollection<Feedback> Feedbacks { get; set; }

		public virtual ApplicationUser User { get; set; }
	}
}
