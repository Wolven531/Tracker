using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tracker.Outside.Adapters
{
	public class HTTPAdapter : IHTTPAdapter
	{
		private readonly HttpClient _httpClient;

		public HTTPAdapter()
		{
			_httpClient = new HttpClient();
		}

		public Task<HttpResponseMessage> Get(Uri requestUri)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
			return _httpClient.SendAsync(request);
		}

		public Task<HttpResponseMessage> Post(Uri requestUri, HttpContent content)
		{
			var request = new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = content };
			return _httpClient.SendAsync(request);
		}

		public Task<HttpResponseMessage> Put(Uri requestUri, HttpContent content)
		{
			var request = new HttpRequestMessage(HttpMethod.Put, requestUri) { Content = content };
			return _httpClient.SendAsync(request);
		}
	}
}
