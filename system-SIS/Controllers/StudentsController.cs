//using Microsoft.AspNetCore.Mvc;
//using system_SIS.Models;
//using system_SIS.Services;

//namespace system_SIS.Controllers
//{
//	public class StudentsController : Controller
//	{
//		public StudentsController(ApplicationDBContext context, IWebHostEnvironment environment)
//		{
//			this.Context = context;
//		}

//		public ApplicationDBContext Context { get; }

//		public IActionResult Index()
//		{
//			// students in white color is the name of the table in the database (dbSis)
//			var students = Context.Students.ToList();
//			return View(students);
//		}

//		public IActionResult Create()
//		{
//			return View();
//		}

//		[HttpPost]
//		public IActionResult Create(AddStudent addStudent)
//		{

//			if (!ModelState.IsValid)
//			{
//				return View(addStudent);
//			}

//			// save data to the database
//			Students student = new Students()
//			{
//				Name = addStudent.Name,
//				DateofBirth = addStudent.DateofBirth
//			};

//			Context.Students.Add(student);
//			Context.SaveChanges();

//			return RedirectToAction("Index", "Students");
//		}

//		public IActionResult Edit(int id)
//		{
//			var student = Context.Students.Find(id);

//			if (student == null)
//			{
//				return RedirectToAction("Index", "Students");
//			}

//			var addStudent = new AddStudent()
//			{
//				Name = student.Name,
//				DateofBirth = student.DateofBirth
//			};

//			ViewData["StudentId"] = id;

//			return View(addStudent);

//		}

//		[HttpPost]
//		public IActionResult Edit(int id, AddStudent addStudent)
//		{
//			var student = Context.Students.Find(id);

//			if (student == null)
//			{
//				return RedirectToAction("Index", "Students");

//			}

//			if (!ModelState.IsValid)
//			{
//				ViewData["StudentId"] = id;

//				return View(addStudent);
//			}

//			// update data to the database
//			student.Name = addStudent.Name;
//			student.DateofBirth = addStudent.DateofBirth;

//			Context.SaveChanges();

//			return RedirectToAction("Index", "Students");
//		}

//		public IActionResult Delete(int id)
//		{
//			var student = Context.Students.Find(id);
//			if (student == null)
//			{
//				return RedirectToAction("Index", "Students");
//			}

//			Context.Students.Remove(student);
//			Context.SaveChanges(true);

//			return RedirectToAction("Index", "Students");
//		}

//	}
//}
