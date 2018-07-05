using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podium.Models
{
	public class Teacher	{

		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Classname { get; set; }		
		public bool IsAdmin { get; set; } = true;

	}
}