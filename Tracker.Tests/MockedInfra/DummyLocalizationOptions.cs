using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Options;
using System;

namespace Tracker.Tests.MockedInfra
{
	class DummyLocalizationOptions : IOptions<MvcDataAnnotationsLocalizationOptions>
	{
		public MvcDataAnnotationsLocalizationOptions Value => throw new NotImplementedException();
	}
}
