using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServer.Lib.Factory;

namespace ApiServer.Controllers
{
    [Produces("application/json")]
    [Route("api/ticket")]
    public class TicketController : Controller
    {
		// GET api/values
		[HttpGet]
		public IActionResult Get(string apiKey, string assignedTo = "me")
		{
			var item = Factory.GetTickets(apiKey, assignedTo);
			return new ObjectResult(item);
		}

		// GET api/ticket/{id}
		[HttpGet("{id}")]
		public IActionResult Get(int id, string apiKey)
		{
			var item = Factory.GetTicket(apiKey, id.ToString());
			return new ObjectResult(item);
		}
	}
}