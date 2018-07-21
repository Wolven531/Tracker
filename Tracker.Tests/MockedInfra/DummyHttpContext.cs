﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;

namespace Tracker.Tests.MockedInfra
{
	class DummyHttpContext : HttpContext
	{
		private readonly HttpRequest _request;

		public DummyHttpContext(HttpRequest request)
		{
			_request = request;
		}

		public override IServiceProvider RequestServices { get => new DummyServiceProvider(); set => throw new NotImplementedException(); }

		public override IFeatureCollection Features => throw new NotImplementedException();
		public override HttpRequest Request => _request;
		public override HttpResponse Response => throw new NotImplementedException();
		public override ConnectionInfo Connection => throw new NotImplementedException();
		public override WebSocketManager WebSockets => throw new NotImplementedException();
		public override ClaimsPrincipal User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override IDictionary<object, object> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public override void Abort()
		{
			throw new NotImplementedException();
		}
		[Obsolete]
		public override AuthenticationManager Authentication => throw new NotImplementedException();
	}
}
