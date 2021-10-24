using Microsoft.AspNetCore.Mvc;
using ConferencePlanner.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferencePlanner.REST.Sessions.Commands.Add;
using ConferencePlanner.REST.Sessions.Queries.GetSession;
using ConferencePlanner.REST.Sessions.Queries.GetSessions;

namespace ConferencePlanner.Controllers {
    public class SessionsController : ApiControllerBase {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddSessionCommand command) {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<List<Session>> GetSessions() => await Mediator.Send(new GetSessionsQuery(1));

        [HttpGet("{id}")]
        public async Task<Session> GetSession(int id) => await Mediator.Send(new GetSessionQuery(id));
    }
}
