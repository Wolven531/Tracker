using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tracker.Tests.MockedInfra
{
	public static class TestServerFactory
	{
		public static TestServer CreateTestServer()
		{
			return new TestServer(CreateWebHostBuilder<TestStartup>());
		}

		public static TestServer CreateTestServer(Action<IServiceCollection> customServices)
		{
			return new TestServer(CreateWebHostBuilder<TestStartup>().ConfigureServices(customServices));
		}

		public static IServiceScope CreateServiceScope(Action<IServiceCollection> customServices)
		{
			var mock = new Mock<IServiceScope>();
			var colelction = new ServiceCollection();
			customServices(colelction);
			mock.Setup(s => s.ServiceProvider).Returns(colelction.BuildServiceProvider());
			return mock.Object;
		}

		private static IWebHostBuilder CreateWebHostBuilder<T>() where T : class
		{
			return new WebHostBuilder()
				.ConfigureAppConfiguration((context, builder) =>
				{
					builder.AddEnvironmentVariables();
					if (context.HostingEnvironment.IsDevelopment())
					{
						builder.AddUserSecrets("a2e.admin");
					}
				})
				.ConfigureLogging((context, builder) =>
				{
					builder.ClearProviders();
					var logLevelString = context.Configuration["LogLevel"];
					var appLogLevel = LogLevel.Information;
					if (logLevelString != null)
					{
						appLogLevel = Enum.Parse<LogLevel>(logLevelString);
					}
					builder.AddFilter(level => level >= appLogLevel);
					builder.AddConsole();
				})
				.UseStartup<T>();
		}
	}
}