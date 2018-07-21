using System;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Tracker.Tests.MockedInfra
{
	public abstract class TestServerFixture : IDisposable
	{
		protected readonly TestServer TestServer;

		protected TestServerFixture()
		{
			TestServer = TestServerFactory.CreateTestServer(RegisterServices);
		}

		public void Dispose()
		{
			TestServer?.Dispose();
		}

		protected T GetService<T>()
		{
			return TestServer.Host.Services.GetService<T>();
		}

		protected virtual void RegisterServices(IServiceCollection customServices)
		{
		}
	}
}