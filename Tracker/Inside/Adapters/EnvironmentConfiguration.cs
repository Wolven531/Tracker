using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Tracker.Inside.Adapters
{
	public class EnvironmentConfiguration : IEnvironmentConfiguration
	{
		public EnvironmentConfiguration(IConfiguration configuration)
		{
			//var someKey = JObject.Parse(configuration["key"]);
		}
	}
}
