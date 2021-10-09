using System.Collections.Generic;

namespace ConferencePlanner.GraphQL.Models {
    public class Attendee {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public ICollection<SessionAttendee> SessionsAttendees { get; set; } =
            new List<SessionAttendee>();
    }
}
