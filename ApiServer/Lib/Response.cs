using System;
using System.Collections.Generic;
using System.Text;

namespace Lib
{
    public class Response
    {

		public Dictionary<int, Ticket> Issues { get; set; } = new Dictionary<int, Ticket>();

		public Dictionary<int, User> Users { get; set; } = new Dictionary<int, User>();

		public Dictionary<int, Project> Projects { get; set; } = new Dictionary<int, Project>();

		public Dictionary<int, Record> Records { get; set; } = new Dictionary<int, Record>();

	}

	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

	public class Ticket
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int ProjectId { get; set; }

		public int AuthorId { get; set; }

		public int AssignedId { get; set; }

		public List<int> NoteIds { get; set; }
	}

	public class Project
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}

	public class Record
	{
		public int Id { get; set; }

		public int AuthorId { get; set; }

		public string Commentary { get; set; }
	}
}
