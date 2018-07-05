using Podium.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Podium.Controllers
{
    public class TeachersController : ApiController    {

		private PodiumDBContext db = new PodiumDBContext();

		[HttpGet]
		[ActionName("List")]
		public IEnumerable<Teacher> List()
		{
			return db.Teachers.ToList();

		}
		[HttpGet]
		[ActionName("Get")]
		public Teacher Get(int? id)
		{
			if (id == null)
				return null;
			return db.Teachers.Find(id);
		}
		[HttpPost]
		[ActionName("Create")]
		public bool Create(Teacher teacher)
		{
			if (teacher == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			db.Teachers.Add(teacher);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Change")]
		public bool Change(Teacher teacher)
		{
			if (teacher == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var teach = db.Teachers.Find(teacher.Id);
			teach.Firstname = teacher.Firstname;
			teach.Lastname = teacher.Lastname;			
			teach.Classname = teacher.Classname;
			teach.IsAdmin = teacher.IsAdmin;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		[ActionName("Remove")]
		public bool Remove(Teacher teacher)
		{
			if (teacher == null)
				return false;
			if (!ModelState.IsValid) {
				return false;
			}
			var teach = db.Teachers.Find(teacher.Id);
			db.Teachers.Remove(teach);
			db.SaveChanges();
			return true;
		}
	}
}
