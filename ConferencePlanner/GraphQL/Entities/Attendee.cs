using System.Collections.Generic;

namespace ConferencePlanner.GraphQL.Entities {
    public class Attendee {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
