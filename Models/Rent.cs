using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
	public class Rent
	{
		[Key]
		public int Id { get; set; }

		[Required]
        [DisplayName("Öğrenci ID")]
        public int studentId { get; set; }

		[ValidateNever]
        [DisplayName("Kitap İsmi")]
        public int BookId { get; set; }
		[ForeignKey("BookId")]

		[ValidateNever]
		public Book Book { get; set; }
	}
}
