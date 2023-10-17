using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class BookType
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(25)]
		[DisplayName("Kitap Türü")]
		public string Name { get; set; }
	}
}
