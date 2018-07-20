using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
	[Route("api/[controller]")]
	public class SampleDataController : Controller
	{
		private static string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[HttpGet("[action]")]
		public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
		{
			var rng = new Random();
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				FormattedDate = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
				TemperatureCelsius = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			});
		}

		public class WeatherForecast
		{
			public string FormattedDate { get; set; }
			public int TemperatureCelsius { get; set; }
			public string Summary { get; set; }

			public int TemperatureFarenheit
			{
				get
				{
					return 32 + (int)(TemperatureCelsius / 0.5556);
				}
			}
		}
	}
}
