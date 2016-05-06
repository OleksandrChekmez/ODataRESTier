using RestierTestWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace RestierTestWebApplication.Controllers
{
	public class TestController : ODataController
	{
		private TestApi api;

		private TestApi Api
		{
			get
			{
				if (api == null)
				{
					api = new TestApi();
				}

				return api;
			}
		}

		private Entities DbContext
		{
			get
			{
				return Api.Context;
			}
		}

		/// <summary>
		/// Disposes the API and the controller.
		/// </summary>
		/// <param name="disposing">Indicates whether disposing is happening.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.api != null)
				{
					this.api.Dispose();
				}
			}

			base.Dispose(disposing);
		}
	}
}