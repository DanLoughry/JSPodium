using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Podium.Models
{
	public class PodiumDBContext : DbContext
	{

		public PodiumDBContext() : base() { }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
	}
}