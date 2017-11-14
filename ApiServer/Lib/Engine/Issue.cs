using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Lib.Engine
{
    public class Issue : BaseEngine
    {
		public static RedmineDLL.Issue GetIssue(string apiKey, string issueId)
		{
			return MakeRequest<RedmineDLL.MainResponse>(apiKey, $"/issues.json?include=journals&issue_id={issueId}").Result.Issue;
		}

		public static List<RedmineDLL.Issue> GetByUser(string apiKey, string userId)
		{
			RedmineDLL.MainResponse response;
			var result = new List<RedmineDLL.Issue>();
			var offset = 0;

			do
			{
				response = MakeRequest<RedmineDLL.MainResponse>(apiKey, $"/issues.json?include=journals&limit=500&offset={offset.ToString()}&assigned_to_id={userId}").Result;
				result.AddRange(response.Issues);
				offset += 500;
			}
			while (response.TotalCount > result.Count);

			return result;
		}

		public static List<RedmineDLL.Issue> GetByProject(string apiKey, string projectId)
		{
			RedmineDLL.MainResponse response;
			var result = new List<RedmineDLL.Issue>();
			var offset = 0;

			do
			{
				response = MakeRequest<RedmineDLL.MainResponse>(apiKey, $"/issues.json?include=journals&limit=500&offset={offset.ToString()}&project_id={projectId}").Result;
				result.AddRange(response.Issues);
				offset += 500;
			}
			while (response.TotalCount > result.Count);

			return result;
		}
	}
}
