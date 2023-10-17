using BookStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Utility
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<BookType> BookTypes { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Rent> Rents { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

	}
}
