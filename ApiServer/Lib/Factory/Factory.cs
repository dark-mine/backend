using Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiServer.Lib.Factory
{
	public class Factory
	{

		public static Response GetTicket(string apiKey, string issueId)
		{
			var response = new Response();
			var issues = new List<RedmineDLL.Issue>();

			issues.Add(Engine.Issue.GetIssue(apiKey, issueId));

			return response;
		}

		public static Response GetTickets(string apiKey, string assignedTo = null, string projectId = null)
		{
			var response = new Response();
			var issues = new List<RedmineDLL.Issue>();

			#region Make requests

			if (assignedTo != null && projectId == null)
			{
				issues.AddRange(Engine.Issue.GetByUser(apiKey, assignedTo));
			}

			if (assignedTo == null && projectId != null)
			{
				issues.AddRange(Engine.Issue.GetByProject(apiKey, projectId));
			}

			#endregion

			#region Handle responses

			Ticket ticket;
			User user;
			Project project;
			foreach (var issue in issues)
			{
				ticket = new Ticket();

				ProcessIssueToTicket(ticket, issue);
				
				response.Issues.Add(ticket.Id, ticket);

				user = new User();
				user.Id = issue.Author.Id;
				user.Name = issue.Author.Name;
				response.Users.TryAdd(issue.Author.Id, user);

				user = new User();
				user.Id = issue.Assigned.Id;
				user.Name = issue.Assigned.Name;
				response.Users.TryAdd(issue.Assigned.Id, user);

				project = new Project();
				project.Id = issue.Project.Id;
				project.Name = issue.Project.Name;
				response.Projects.TryAdd(project.Id, project);
			}

			#endregion

			return response;
		}

		private static void ProcessIssueToTicket(Ticket ticket, RedmineDLL.Issue issue)
		{
			ticket.Id = issue.Id;
			ticket.Name = issue.Subject;
			ticket.ProjectId = issue.Project.Id;
			ticket.Description = issue.Description;
			ticket.AssignedId = issue.Assigned.Id;
			ticket.AuthorId = issue.Author.Id;

			ticket.NoteIds = new List<int>();
			if (issue.Journals != null)
			{
				foreach (var note in issue.Journals)
				{
					ticket.NoteIds.Add(note.Id);
				}
			}
		}

    }
}
