using Microsoft.AspNetCore.Mvc;
using ConferencePlanner.Entities;
using System.Threading.Tasks;
using ConferencePlanner.REST.Sessions.Commands.Add;
using ConferencePlanner.REST.Sessions.Queries.GetSession;

namespace ConferencePlanner.Controllers {
    public class SessionsController : ApiControllerBase {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddSessionCommand command) {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<Session> GetSession(int id) => await Mediator.Send(new GetSessionQuery(id));
    }
}
