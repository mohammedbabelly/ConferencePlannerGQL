using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.Entities {
    public class Session {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public SessionAttendType Type { get; set; }

        public int? TrackId { get; set; }
        public int? SpeakerId { get; set; }

        public Track? Track { get; set; }
        public Speaker? Speaker { get; set; }
        public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
        public TimeSpan Duration => EndTime?.Subtract(StartTime ?? EndTime ?? DateTimeOffset.MinValue) ?? TimeSpan.Zero;
    }
    public enum SessionAttendType {
        OnlyParticipants, 
        ForAll
    }

}
