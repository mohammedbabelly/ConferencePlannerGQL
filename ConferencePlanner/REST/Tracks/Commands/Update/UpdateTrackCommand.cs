using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Tracks.Commands.Update {

    public record UpdateTrackCommand(string NewName, int OldId) : IRequest<Track> { }

    public class AddTrackCommandHandler : IRequestHandler<UpdateTrackCommand, Track> {
        private readonly IApplicationDbContext _context;

        public AddTrackCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Track> Handle(UpdateTrackCommand request, CancellationToken cancellationToken) {
            var track = await _context.Tracks.FindAsync(request.OldId);
            if (track == null)
                throw new Exception($"Track with id {request.OldId} was not found!");
            track.Name = request.NewName;
            await _context.SaveChangesAsync(cancellationToken);
            return track;
        }

    }
}
