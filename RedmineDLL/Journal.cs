using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedmineDLL
{
	public class Journal
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("user")]
		public IdNameItem Author { get; set; }

		[JsonProperty("created_on")]
		public string CreatedAt { get; set; }

		[JsonProperty("notes")]
		public string Text { get; set; }
    }
}
