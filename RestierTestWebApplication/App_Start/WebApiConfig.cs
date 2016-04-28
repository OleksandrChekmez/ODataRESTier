using Microsoft.Restier.WebApi.Batch;
using RestierTestWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using Microsoft.Restier.WebApi;
using System.Web.OData.Builder;

namespace RestierTestWebApplication
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			RegisterRestier(config, GlobalConfiguration.DefaultServer);

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		public static async void RegisterRestier(HttpConfiguration config, HttpServer server)
		{
			await config.MapRestierRoute<TestApi>(
				"TestApi", "api/Test",
				new RestierBatchHandler(server));
		}
	}
}
