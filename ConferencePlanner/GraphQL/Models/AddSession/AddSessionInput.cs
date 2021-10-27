using System;

namespace ConferencePlanner.Entities {
    public class AddSessionInput{
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public int? TrackId { get; set; }
        public SessionAttendType Type { get; set; }
    }
}
