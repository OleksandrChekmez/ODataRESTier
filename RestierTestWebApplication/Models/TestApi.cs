using Microsoft.Restier.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestierTestWebApplication.Models
{
	public class TestApi : DbApi<Entities>
	{
		public Entities Context
		{
			get
			{
				return DbContext;
			}
		}
	}
}