using Microsoft.AspNetCore.Mvc.Internal;
using System.IO;
using System.Text;

namespace Tracker.Tests.MockedInfra
{
	class DummyWriterFactory : IHttpResponseStreamWriterFactory
	{
		public TextWriter CreateWriter(Stream stream, Encoding encoding)
		{
			return new DummyTextWriter(encoding);
		}
	}
}
