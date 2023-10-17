using BookStore.Models;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class BookTypeController : Controller
	{
		private readonly IBookTypeRepository _bookTypeRepository;
		public BookTypeController(IBookTypeRepository context)
		{
			_bookTypeRepository = context;
		}
		public IActionResult Index()
		{
			List<BookType> objBookTypeList = _bookTypeRepository.GetAll().ToList();
			return View(objBookTypeList);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(BookType bookType)
		{
			if(ModelState.IsValid)
			{
				_bookTypeRepository.Add(bookType);
				_bookTypeRepository.Save();
				TempData["success"] = "Yeni Kitap Türü Başarıyla Oluşturuldu!";
				return RedirectToAction("Index", "BookType");
			}
			return View();
		}
		public IActionResult Update(int? id)
		{
			if(id== null || id == 0)
			{
				return NotFound();
			}
			BookType? bookTypeDb = _bookTypeRepository.Get(u => u.Id == id);
			if (bookTypeDb == null)
			{
				return NotFound();
			}
			return View(bookTypeDb);
		}
		[HttpPost]
		public IActionResult Update(BookType bookType)
		{
			if (ModelState.IsValid)
			{
				_bookTypeRepository.Update(bookType);
				_bookTypeRepository.Save();
				TempData["success"] = "Kitap Türü Başarıyla Güncellendi!";
				return RedirectToAction("Index", "BookType");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			BookType? bookTypeDb = _bookTypeRepository.Get(u => u.Id == id);
			if (bookTypeDb == null)
			{
				return NotFound();
			}
			return View(bookTypeDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteBookType(int? id)
		{
			BookType? bookType = _bookTypeRepository.Get(u => u.Id == id);
			if(bookType == null)
			{
				return NotFound();
			}
			_bookTypeRepository.Delete(bookType);
			_bookTypeRepository.Save();
			TempData["success"] = "Kitap Türü Başarıyla Silindi!";
			return RedirectToAction("Index","BookType");
		}
	}
}
