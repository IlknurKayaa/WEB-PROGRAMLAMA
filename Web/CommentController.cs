using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebProje1.Controllers
{
	public class CommentController : Controller
	{
        CommentManager cm = new CommentManager(new EFCommentRepository());
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult PartialAddComment()
		{
			return View();
		}
        [HttpPost]
        public IActionResult PartialAddComment(Comment c)
        {
			c.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.ArticleID = 1;
			cm.CommentAdd(c);
			return RedirectToAction("ArticleReadAll", "Article", new {id=c.ArticleID});

		}
		public PartialViewResult CommentListByArticle(int id)
		{
			var values = cm.GetAllComment(id);
			return PartialView(values);
		}
	}
}
