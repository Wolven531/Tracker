using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Tracker.Outside.Adapters;

namespace Tracker
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		private readonly ILogger<Startup> _logger;
		private readonly IHostingEnvironment _hostingEnvironment;
		//private EnvironmentConfiguration _environmentConfiguration;

		public Startup(ILogger<Startup> logger, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
		{
			_logger = logger;
			_hostingEnvironment = hostingEnvironment;
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(config =>
			{
				//if (_hostingEnvironment.IsProduction())
				//{
				//	config.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
				//}
			}).AddJsonOptions(options =>
			{
				options.SerializerSettings.Converters.Add(new StringEnumConverter(true));
				options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			});

			_logger.LogCritical($"Logging level set to normal...");
			//_environmentConfiguration = new EnvironmentConfiguration(Configuration);
			//services.TryAddSingleton<IEnvironmentConfiguration>(_environmentConfiguration);

			services.TryAddSingleton<IHTTPAdapter, HTTPAdapter>();

			//if (_hostingEnvironment.IsProduction())
			//{
			//	services
			//		.AddAuthentication(options =>
			//			{
			//				options.DefaultScheme = "Cookies";
			//				options.DefaultChallengeScheme = "oidc";
			//			})
			//		.AddCookie("Cookies")
			//		.AddOpenIdConnect("oidc", options =>
			//		{
			//			options.SignInScheme = "Cookies";
			//			//options.Authority = _environmentConfiguration.ISEndpoint.OriginalString;
			//			options.ClientId = "unified-tracker";
			//			options.ResponseType = "id_token";
			//			options.SaveTokens = true;
			//		});
			//}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				AddWebpackMiddleware(app);
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			//app.UseAuthentication();
			app.UseStaticFiles();

			app.UseMvc(
				routes => routes.MapRoute(
					"default",
					"{controller=Home}/{action=Index}/{id?}"
				)
			);

			// NOTE: only try SPA fallback at this point if not an API request
			app.MapWhen(x => !x.Request.Path.Value.StartsWith("/api"), builder =>
			{
				builder.UseMvc(
					routes =>
						routes.MapSpaFallbackRoute(
							"spa-fallback",
							new
							{
								controller = "Home",
								action = "Index"
							}
					)
				);
			});
		}

		protected virtual void AddWebpackMiddleware(IApplicationBuilder app)
		{
			app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
			{
				HotModuleReplacement = true,
				ReactHotModuleReplacement = true
			});
		}
	}
}
