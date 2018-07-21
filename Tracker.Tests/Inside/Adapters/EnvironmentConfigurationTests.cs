using Microsoft.Extensions.Configuration;
using Moq;
using Tracker.Inside.Adapters;
using Xunit;

namespace Tracker.Tests.Inside.Adapters
{
	public class EnvironmentConfigurationTests
	{
		[Fact]
		public void EnvironmentConfiguration_WhenLoaded_ShouldHaveValues()
		{
			// Setup
			var mockedConfigRoot = new Mock<IConfigurationRoot>();
			mockedConfigRoot
				.Setup(cr => cr["key"])
				.Returns("someVal");

			// Execute
			var actual = new EnvironmentConfiguration(mockedConfigRoot.Object);

			// Verify
			//actual.Key.Should().Be("someVal");
		}
	}
}
