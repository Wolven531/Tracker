using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;

namespace Tracker.Tests.MockedInfra
{
	class DummyHttpRequest : HttpRequest
	{
		private readonly HttpContext _context;

		private string _host;
		private string _method;
		private string _path;
		private string _protocol;
		private string _queryString;

		// public DummyHttpRequest(HttpContext context, string method, string host, string path, string queryString = "", string protocol = "http")
		public DummyHttpRequest(string method, string host, string path, string queryString = "", string protocol = "http")
		{
			// _context = context;

			_host = host;
			_method = method;
			_path = path;
			_protocol = protocol;
			_queryString = queryString;
		}

		public override string Method { get => _method; set => _method = value; }
		public override HttpContext HttpContext => _context;
		public override HostString Host { get => new HostString(_host); set => _host = value.Host; }
		public override PathString Path { get => _path; set => _path = value; }
		public override QueryString QueryString { get => new QueryString(_queryString); set => _queryString = value.Value; }
		public override string Protocol { get => _protocol; set => _protocol = value; }
		public override bool IsHttps { get => _protocol.Equals("https"); set => throw new NotImplementedException(); }

		public override string Scheme { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override PathString PathBase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override IQueryCollection Query { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override IHeaderDictionary Headers => throw new NotImplementedException();
		public override IRequestCookieCollection Cookies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override long? ContentLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override string ContentType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override Stream Body { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override bool HasFormContentType => throw new NotImplementedException();
		public override IFormCollection Form { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new NotImplementedException();
		}
	}
}
