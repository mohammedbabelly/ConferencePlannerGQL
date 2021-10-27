using ConferencePlanner.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Data {
    public interface IApplicationDbContext {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
