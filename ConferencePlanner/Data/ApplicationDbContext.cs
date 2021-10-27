using ConferencePlanner.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.Data {
    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Track> Tracks { get; set; } = default!;
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<Attendee> Attendees { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            => base.SaveChangesAsync(cancellationToken);
    }
}
