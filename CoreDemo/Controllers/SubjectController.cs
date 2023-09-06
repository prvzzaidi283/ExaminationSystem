using CoreDemo.Model;
using CoreDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Net;

namespace CoreDemo.Controllers
{
	public class SubjectController : Controller
	{
		public ISubjectService _subjectservice;
		public SubjectController( ISubjectService subjectService) 
		{
		
		 _subjectservice = subjectService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Subject()
		{
			ViewBag.categories = new SelectList(getCategories().Result, "Id", "CategoryName");
			return View();
		}

		public async Task<List<Category>> getCategories()
		{
			var list = new List<Category>();
			list = await _subjectservice.GetCategoriesAsync();
			return list;
		}

		[HttpPost]
		[ActionName("processSubjectTask")]
		public ActionResult processSubjectTask(Subject request)
		{
			string resultMsg = string.Empty;
			if (request != null)
			{
				try
				{
					var result = _subjectservice.SaveUpdateSubject(request).Result;
					if (result)
					{
						resultMsg = "Record save successfully.";

					}
					else
					{
						resultMsg = "Error occured in processing.";
					}
				}
				catch (Exception ex)
				{
					resultMsg = ex.Message.ToString();
					Response.StatusCode = (int)HttpStatusCode.BadRequest;
				}
				
			}

			return Json(resultMsg);
		}

		public async Task<JsonResult> GetSubjectList()
		{
			var taskDetails = await _subjectservice.GetSubjectListAsync();
			return Json(taskDetails);
		}

		public async Task<JsonResult> GetSubjectById(int Id)
		{
			var catDetails = await _subjectservice.GetSubjectById(Id);
			return Json(catDetails);
		}
	}
}
