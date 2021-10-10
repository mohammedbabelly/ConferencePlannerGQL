using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.Entities {
    public class Track {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public ICollection<Session>? Sessions { get; set; } = new List<Session>();
    }
}
