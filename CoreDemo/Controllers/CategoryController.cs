using CoreDemo.Model;
using CoreDemo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreDemo.Controllers
{
	public class CategoryController : Controller
	{
		public readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{ 
		 _categoryService = categoryService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Category()
		{

			return View("Category");
		}
		[HttpPost]
		[ActionName("processCategoryTask")]
		public ActionResult processCategoryTask(Category request)
		{
			string resultMsg = string.Empty;
			if (request != null)
			{
				try
				{
					var result = _categoryService.AddUpdateCategory(request).Result;
					if (result)
					{
						resultMsg = "Record save successfully.";

					}
					else
					{
						resultMsg = "Error occured in processing.";
					}
				}
				catch(Exception ex) {
					resultMsg = ex.Message.ToString();
					Response.StatusCode = (int)HttpStatusCode.BadRequest;
				}
				
			}

			return Json(resultMsg);
		}

		public async Task<JsonResult> GetCategoryList()
		{
			var taskDetails = await _categoryService.GetList();
			return Json(taskDetails);
		}

		public async Task<JsonResult> GetCategoryById(int Id)
		{
			var catDetails = await _categoryService.GetCategoryById(Id);
			return Json(catDetails);
		}
	}
}
