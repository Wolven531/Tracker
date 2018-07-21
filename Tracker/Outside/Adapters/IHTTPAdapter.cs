using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tracker.Outside.Adapters
{
	public interface IHTTPAdapter
	{
		Task<HttpResponseMessage> Get(Uri requestUri);

		Task<HttpResponseMessage> Post(Uri requestUri, HttpContent content);

		Task<HttpResponseMessage> Put(Uri requestUri, HttpContent content);
	}
}