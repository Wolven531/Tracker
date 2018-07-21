using Tracker.Outside.Controllers;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tracker.Tests.MockedInfra;

namespace Tracker.Tests.Outside.Controllers
{
	public class HomeControllerTests
	{
		[Fact]
		public async Task Index_WhenInvokedWithCustomContext_ShouldRenderHomeView()
		{
			// Setup
			var fixture = new HomeController();
			var actual = fixture.Index();
			var actionContext = new ActionContext(
					new DummyHttpContext(
						new DummyHttpRequest("get", "somehost", "somepath")
					),
					new RouteData(),
					new ActionDescriptor(),
					new ModelStateDictionary()
				);

			// Execute
			await actual.ExecuteResultAsync(actionContext);

			// Verify
			actual.Should().Be("");
		}

		[Fact]
		public void Index_WhenInvoked_ShouldRenderHomeView()
		{
			// Setup
			var fixture = new HomeController();

			// Execute
			var actual = fixture.Index() as ContentResult;

			// Verify
			actual.Content.Should().Be("");
		}
	}
}
