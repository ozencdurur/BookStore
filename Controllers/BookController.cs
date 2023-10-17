using BookStore.Models;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
	
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepository;
		private readonly IBookTypeRepository _bookTypeRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;
		public BookController(IBookRepository bookRepository, IBookTypeRepository bookTypeRepository, IWebHostEnvironment webHostEnvironment)
		{
			_bookRepository = bookRepository;
			_bookTypeRepository = bookTypeRepository;
			_webHostEnvironment = webHostEnvironment;
		}

        [Authorize(Roles = "Admin, Student")]
        public IActionResult Index()
		{
			List<Book> objBookList = _bookRepository.GetAll(includeProps: "BookType").ToList();
			return View(objBookList);
		}

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult AddUpdate(int? id)
		{
			IEnumerable<SelectListItem> BookTypeList = _bookTypeRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.Name,
				Value = k.Id.ToString()
			});
			ViewBag.BookTypeList = BookTypeList;
			if(id==null || id == 0)
			{
				return View();
			}
			else
			{
				Book? bookDb = _bookRepository.Get(u => u.Id == id);
				if (bookDb == null)
				{
					return NotFound();
				}
				return View(bookDb);
			}
		}

		[HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult AddUpdate(Book book, IFormFile? file)
		{
			if(ModelState.IsValid)
			{
				string wwwRootPath = _webHostEnvironment.WebRootPath;
				string bookPath = Path.Combine(wwwRootPath, @"img");
				if(file != null)
				{
					using (var fileStream = new FileStream(Path.Combine(bookPath, file.FileName), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					book.ImageUrl = @"\img\" + file.FileName;
				}
				if(book.Id == 0)
				{
					_bookRepository.Add(book);
					TempData["success"] = "Yeni Kitap Başarıyla Oluşturuldu!";
				}
				else
				{
					_bookRepository.Update(book);
					TempData["success"] = "Kitap Başarıyla Güncellendi!";
				}
				_bookRepository.Save();
				return RedirectToAction("Index", "Book");
			}
			return View();
		}

        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Book? bookDb = _bookRepository.Get(u => u.Id == id);
			if (bookDb == null)
			{
				return NotFound();
			}
			return View(bookDb);
		}

        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost, ActionName("Delete")]
		public IActionResult DeleteBook(int? id)
		{
			Book? book = _bookRepository.Get(u => u.Id == id);
			if(book == null)
			{
				return NotFound();
			}
			_bookRepository.Delete(book);
			_bookRepository.Save();
			TempData["success"] = "Kitap Başarıyla Silindi!";
			return RedirectToAction("Index","Book");
		}
	}
}
