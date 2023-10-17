using BookStore.Models;
using BookStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class RentController : Controller
	{
		private readonly IRentRepository _rentRepository;
		private readonly IBookRepository _bookRepository;
		public readonly IWebHostEnvironment _webHostEnvironment;
		public RentController(IRentRepository rentRepository, IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
		{
			_rentRepository = rentRepository;
			_bookRepository = bookRepository;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			List<Rent> objRentList = _rentRepository.GetAll(includeProps: "Book").ToList();
			return View(objRentList);
		}
		public IActionResult AddUpdate(int? id)
		{
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.BookName,
				Value = k.Id.ToString()
			});
			ViewBag.BookList = BookList;
			if(id==null || id == 0)
			{
				return View();
			}
			else
			{
				Rent? rentDb = _rentRepository.Get(u => u.Id == id);
				if (rentDb == null)
				{
					return NotFound();
				}
				return View(rentDb);
			}
		}
		[HttpPost]
		public IActionResult AddUpdate(Rent rent)
		{
			if(ModelState.IsValid)
			{
				
				if(rent.Id == 0)
				{
					_rentRepository.Add(rent);
					TempData["success"] = "Yeni Kitap Kiralama Başarıyla Oluşturuldu!";
				}
				else
				{
					_rentRepository.Update(rent);
					TempData["success"] = "Kitap Kiralama Başarıyla Güncellendi!";
				}
				_rentRepository.Save();
				return RedirectToAction("Index", "Rent");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(k => new SelectListItem
			{
				Text = k.BookName,
				Value = k.Id.ToString()
			});
			ViewBag.BookList = BookList;
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Rent? rentDb = _rentRepository.Get(u => u.Id == id);
			if (rentDb == null)
			{
				return NotFound();
			}
			return View(rentDb);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteBook(int? id)
		{
			Rent? rent = _rentRepository.Get(u => u.Id == id);
			if(rent == null)
			{
				return NotFound();
			}
			_rentRepository.Delete(rent);
			_rentRepository.Save();
			TempData["success"] = "Kitap Kiralama Başarıyla Silindi!";
			return RedirectToAction("Index","Rent");
		}
	}
}
