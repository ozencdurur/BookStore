using System.Linq.Expressions;

namespace BookStore.Models
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll(string? includeProps = null);
		T Get(Expression<Func<T, bool>> filter, string? includeProps = null);
		void Add(T entity);
		void Delete(T entity);
		void DeleteSpacing(IEnumerable<T> entities);
	}
}
