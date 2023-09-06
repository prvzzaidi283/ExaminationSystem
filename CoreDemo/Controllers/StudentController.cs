using CoreDemo.Model;
using CoreDemo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace CoreDemo.Controllers
{
	public class StudentController : Controller
	{
		public IStudentService _studentService;
		public StudentController(IStudentService studentService)
		{ 
		_studentService = studentService;	
		}
		public async Task<IActionResult> Index()
		{
			List<Student> studentList = await _studentService.GetStudentListAsync().ConfigureAwait(false);
			
			return View(studentList);
		}

		public IActionResult Create()
		{
			ViewBag.gender = new SelectList(getGenderList(), "Id", "GenderName", "Select");

			return View("CreateStudent");
		}

		[HttpPost]
		[ActionName("processStudentTask")]
		public ActionResult processStudentTask(Student request)
		{
			string resultMsg = string.Empty;
			if (request != null)
			{
				try
				{
					var result = _studentService.SaveUpdateStudent(request).Result;
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


		public async Task<IActionResult> EditStudent(int id) 
		{

            ViewBag.gender = new SelectList(getGenderList(), "Id", "GenderName", "Select");
			Student student = await _studentService.GetStudentById(id);
            return View("CreateStudent",student);

        }

		public List<Gender> getGenderList()
		{
			var list = new List<Gender>();
			list.Add(new Gender { Id = 1, GenderName = "Male" });
			list.Add(new Gender { Id = 2, GenderName = "FeMale" });
			return list;
		}
	}
}
