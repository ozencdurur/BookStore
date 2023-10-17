namespace BookStore.Models
{
	public interface IBookRepository : IRepository<Book>
	{
		void Update(Book book);
		void Save();
	}
}
