using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podium.Models
{
	public class Student	{

		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int Status { get; set; } = 1;
		public bool Loggedin { get; set; } = true;
		public string Classname { get; set; }
		public bool IsAdmin { get; set; } = false;
		
	}
}