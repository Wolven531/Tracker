using Tracker.Outside.Controllers;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Routing;
//using Microsoft.AspNetCore.Mvc.Abstractions;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Tracker.Tests.MockedInfra;
using Moq;
using Tracker.Outside.Adapters;
//using System;
//using System.Net.Http;

namespace Tracker.Tests.Outside.Controllers
{
	public class HomeControllerTests
	{
		//[Fact]
		//public async Task Index_WhenInvokedWithCustomContext_ShouldRenderHomeView()
		//{
		//	// Setup
		//	var fixture = new HomeController();
		//	var actual = fixture.Index();
		//	var actionContext = new ActionContext(
		//			new DummyHttpContext(
		//				new DummyHttpRequest("get", "somehost", "somepath")
		//			),
		//			new RouteData(),
		//			new ActionDescriptor(),
		//			new ModelStateDictionary()
		//		);

		//	// Execute
		//	await actual.ExecuteResultAsync(actionContext);

		//	// Verify
		//	actual.Should().Be("");
		//}

		[Fact]
		public void Index_WhenInvoked_ShouldRenderHomeView()
		{
			// Setup
			var mockHttpAdapter = new Mock<IHTTPAdapter>();
			//Uri actualUri = null;
			//mockHttpAdapter
			//	.Setup(adapter => adapter.Get(It.IsAny<Uri>()))
			//	.Callback<Uri>(uri => actualUri = uri)
			//	.ReturnsAsync(new HttpResponseMessage() {
			//		Content = new StringContent("some stuff")
			//	});
			var fixture = new HomeController(mockHttpAdapter.Object);

			// Execute
			var executionResult = fixture.Index();

			// Verify
			//mockHttpAdapter.VerifyAll();
			//actualUri.Should().NotBeNull();
			//actualUri.GetLeftPart(UriPartial.Path).Should().Be("/");
			executionResult.Should().BeOfType<ViewResult>();
		}
	}
}
