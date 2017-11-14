using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace RedmineDLL
{
	public class Issue
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		
		[JsonProperty("subject")]
		public string Subject { get; set; }
		
		[JsonProperty("description")]
		public string Description { get; set; }
		
		[JsonProperty("author")]
		public IdNameItem Author { get; set; }

		[JsonProperty("project")]
		public IdNameItem Project { get; set; }

		[JsonProperty("assigned_to")]
		public IdNameItem Assigned { get; set; }

		[JsonProperty("start_date")]
		private string StartDate { get; set; }

		[JsonIgnore]
		public DateTime CreatedAt
		{
			get
			{
				return DateTime.ParseExact(StartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			}
		}
		
		public List<Journal> Journals { get; set; }
    }
}
