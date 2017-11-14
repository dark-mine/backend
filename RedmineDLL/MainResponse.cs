using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedmineDLL
{
	public class MainResponse
	{
		[JsonProperty("issue")]
		public Issue Issue { get; set; }

		[JsonProperty("issues")]
		public List<Issue> Issues { get; set; }

		[JsonProperty("total_count")]
		public int TotalCount { get; set; }
	}
}
