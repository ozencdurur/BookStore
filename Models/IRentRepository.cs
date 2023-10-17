namespace BookStore.Models
{
	public interface IRentRepository : IRepository<Rent>
	{
		void Update(Rent rent);
		void Save();
	}
}
