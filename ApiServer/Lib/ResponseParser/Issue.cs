using Lib;
using RedmineDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Lib.ResponseParser
{
    public class Issue
    {
	    
		public static void ParseIssues(Response result, List<RedmineDLL.Issue> issues)
		{
			foreach (var issue in issues)
			{
				Ticket ticket = new Ticket();

				ticket.Id = issue.Id;
				ticket.AuthorId = issue.Author.Id;
				ticket.Description = issue.Description;
				ticket.Name = issue.Subject;
				ticket.ProjectId = issue.Project.Id;
				ticket.AssignedId = issue.Assigned.Id;

				result.Issues.Add(issue.Id, ticket);
			}
		}
    }
}
