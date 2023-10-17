using BookStore.Utility;

namespace BookStore.Models
{
	public class BookRepository : Repository<Book>, IBookRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public BookRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}

		public void Update(Book book)
		{
			_applicationDbContext.Update(book);
		}
	}
}
