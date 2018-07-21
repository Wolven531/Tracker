using System.IO;
using System.Text;

namespace Tracker.Tests.MockedInfra
{
	class DummyTextWriter : TextWriter
	{
		private Encoding _encoding;

		public DummyTextWriter(Encoding encoding)
		{
			_encoding = encoding;
		}

		public override Encoding Encoding => _encoding;
	}
}
