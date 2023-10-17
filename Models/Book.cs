using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }
		
		[Required]
        [DisplayName("Kitap İsmi")]
        public string BookName { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Yazar")]
        [Required]
		public string Author { get; set; }

        [DisplayName("Fiyat")]
        [Required]
		[Range(5, 5000)]
		public double Price { get; set; }

		[ValidateNever]
        [DisplayName("Kitap Türü")]
        public int BookTypeId { get; set; }

		[ValidateNever]
		[ForeignKey("BookTypeId")]
        
        public BookType BookType { get; set; }

		[ValidateNever]
        [DisplayName("Kitap Resmi")]
        public string ImageUrl { get; set; }

	}
}
