using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;

namespace Tracker.Tests.MockedInfra
{
	class DummyServiceProvider : IServiceProvider
	{
		public object GetService(Type serviceType)
		{
			if (serviceType == typeof(ViewResultExecutor))
			{
				return new ViewResultExecutor(
					null,
					new DummyWriterFactory(),
					null,
					null,
					null,
					null,
					null
				);
			}

			return null;
		}
	}
}
