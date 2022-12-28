using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebProje1.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EFWriterRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer w)
		{
			WriterValidator wv = new WriterValidator();
			ValidationResult results=wv.Validate(w);
			if (results.IsValid)
			{
                w.WriterStatus = true;
                w.WriterAbout = "Açıklama";
                wm.WriterAdd(w);
                return RedirectToAction("Index", "Article");
            }
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
			
		}
	}
}
