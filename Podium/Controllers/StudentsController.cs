using Podium.Models;
using Podium.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podium.Controllers
{
    public class StudentsController : ApiController    {

		private PodiumDBContext db = new PodiumDBContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Student> List()
		{
			return db.Students.ToList();

		}
		[HttpGet]
		[ActionName("ClassList")]
		public IEnumerable<Student> ClassList(string classname)
		{
			return db.Students.Where(student => student.Loggedin == true && student.Classname == classname);

		}
		[HttpGet]
		[ActionName("Get")]
		public Student Get(int? id)
		{
			if (id == null)
				return null;
			return db.Students.Find(id);
		}

		[HttpGet]
		[ActionName("GetStudent")]
		public Student GetStudent(LoginAuthentication login)
		{
			if (login == null)
				return null;
			return db.Students.SingleOrDefault(student => student.Firstname == login.Firstname  &&
					 student.Lastname == login.Lastname &&
					student.Password == login.Password);
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Student student)
		{
			if (student == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			db.Students.Add(student);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Student student)
		{
			if (student == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var stud = db.Students.Find(student.Id);
			stud.Firstname = student.Firstname;
			stud.Lastname = student.Lastname;
			stud.Status = student.Status;
			stud.Classname = student.Classname;
			stud.IsAdmin = student.IsAdmin;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Student student)
		{
			if (student == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var stud = db.Students.Find(student.Id);
			db.Students.Remove(stud);
			db.SaveChanges();
			return true;
		}
	}
}
