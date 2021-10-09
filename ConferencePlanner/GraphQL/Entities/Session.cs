using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL.Entities {
    public class Session {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        // Bonus points to those who can figure out why this is written this way
        public TimeSpan Duration =>
            EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ??
                TimeSpan.Zero;

        public int? TrackId { get; set; }

        public ICollection<SessionSpeaker> SessionSpeakers { get; set; } =
            new List<SessionSpeaker>();

        public ICollection<SessionAttendee> SessionAttendees { get; set; } =
            new List<SessionAttendee>();

        public Track? Track { get; set; }
    }
}
