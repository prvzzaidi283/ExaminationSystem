using CoreDemo.Model;
using CoreDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace CoreDemo.Controllers
{
	public class ExamController : Controller
	{
		public IExamService _examService;
		public ExamController(IExamService examService)
		{
			_examService = examService;
		}
		public IActionResult Index()
		{
			ViewBag.categories = new SelectList(getCategories().Result, "Id", "CategoryName");

			return View();
		}

		public async Task<List<Category>> getCategories()
		{
			var list = new List<Category>();
			list = await _examService.GetCategoryList();
			return list;
		}
		public async Task<JsonResult> GetSubjectList(int Id)
		{
			var subjectDetails = await _examService.GetSubjectByCategoryID(Id);
			return Json(subjectDetails);
		}
		public async Task<JsonResult> GetExamList()
		{
			var subjectDetails = await _examService.GetExamList();
			return Json(subjectDetails);
		}

		[HttpPost]
		[ActionName("processExamTask")]
		public ActionResult processExamTask(Exam request)
		{
			string resultMsg = string.Empty;
			if (request != null)
			{
				try
				{
					var result = _examService.SaveUpdateExam(request).Result;
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

		public async Task<JsonResult> GetExamById(int Id)
		{
			var examDetails = await _examService.GetExamById(Id);
			return Json(examDetails);
		}
	}
}
