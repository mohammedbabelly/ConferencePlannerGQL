using ConferencePlanner.REST.Sessions.Queries;
using System.Collections.Generic;

namespace ConferencePlanner.REST.Tracks.Queries {
    public class TrackDto {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<SessionDto>? Sessions { get; set; } = new List<SessionDto>();
    }
}
