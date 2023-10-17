using BookStore.Utility;

namespace BookStore.Models
{
	public class RentRepository : Repository<Rent>, IRentRepository
	{
		private ApplicationDbContext _applicationDbContext;
		public RentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
			_applicationDbContext = applicationDbContext;
		}

		public void Save()
		{
			_applicationDbContext.SaveChanges();
		}

		public void Update(Rent rent)
		{
			_applicationDbContext.Update(rent);
		}
	}
}
