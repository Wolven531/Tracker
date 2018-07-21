using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace Tracker.Tests.MockedInfra
{
	class DummyViewOptions : IOptions<MvcViewOptions>
	{
		public MvcViewOptions Value => throw new NotImplementedException();
	}
}
