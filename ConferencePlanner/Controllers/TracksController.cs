using ConferencePlanner.Entities;
using ConferencePlanner.REST.Tracks.Commands.Add;
using ConferencePlanner.REST.Tracks.Queries.GetTracks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferencePlanner.Controllers {
    public class TracksController : ApiControllerBase {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddTrackCommand command) {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        public async Task<List<Track>> GetTracks() => await Mediator.Send(new GetTracksQuery());

    }
}
