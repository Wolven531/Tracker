using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Tracker.Tests.MockedInfra
{
	// Using this Startup will disable use of Webpack middleware in tests
	public class TestStartup : Startup
	{
		protected override void AddWebpackMiddleware(IApplicationBuilder app)
		{
		}

		public TestStartup(ILogger<Startup> logger, IConfiguration configuration, IHostingEnvironment hostingEnvironment) : base(logger, configuration, hostingEnvironment)
		{
		}
	}
}