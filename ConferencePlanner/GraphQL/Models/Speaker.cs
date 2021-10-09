using System.ComponentModel.DataAnnotations;

namespace ConferencePlanner.GraphQL.Models {
    public class Speaker {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
    }
}
