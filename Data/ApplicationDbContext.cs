
using DAW.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAW.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

        public DbSet<Stiri> Stiri { get; set; }
        public DbSet<Categorii> Categorii { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
    }
}
