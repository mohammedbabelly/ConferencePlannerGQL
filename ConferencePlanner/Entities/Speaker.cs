﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.Entities {
    public class Speaker {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string? Website { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}