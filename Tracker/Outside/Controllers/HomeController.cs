using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tracker.Outside.Adapters;

namespace Tracker.Outside.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHTTPAdapter _HttpAdapter;

		public HomeController(IHTTPAdapter _httpAdapter)
		{
			_HttpAdapter = _httpAdapter;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			return View();
		}
	}
}
