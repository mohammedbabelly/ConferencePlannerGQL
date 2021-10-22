using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Sessions.Commands.Add {

    public record AddSessionCommand(AddSessionInput input) : IRequest<Session> { }

    public class AddSessionCommandHandler : IRequestHandler<AddSessionCommand, Session> {
        private readonly IApplicationDbContext _context;

        public AddSessionCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Session> Handle(AddSessionCommand request, CancellationToken cancellationToken) {
            var track = await _context.Tracks.FindAsync(request.input.TrackId);
            if (track == null)
                throw new System.Exception("Track not found");

            var session = new Session { 
                Title = request.input.Title,
                Description = request.input.Description,
                StartTime = request.input.StartTime,
                EndTime = request.input.EndTime,
                Track = track
            };
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync(cancellationToken);
            return session;
        }

    }
}
