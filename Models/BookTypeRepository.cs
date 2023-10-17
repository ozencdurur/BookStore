using BookStore.Utility;

namespace BookStore.Models
{
	public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public BookTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}

		public void Update(BookType bookType)
		{
			_applicationDbContext.Update(bookType);
		}
	}
}
