using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class QuestionController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
