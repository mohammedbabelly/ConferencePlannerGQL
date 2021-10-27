using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Tracks.Commands.Delete {

    public record DeleteTrackCommand(int Id) : IRequest<Track> { }

    public class DeleteTrackCommandHandler : IRequestHandler<DeleteTrackCommand, Track> {
        private readonly IApplicationDbContext _context;

        public DeleteTrackCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Track> Handle(DeleteTrackCommand request, CancellationToken cancellationToken) {
            var track = await _context.Tracks.FindAsync(request.Id);
            if (track == null)
                throw new Exception($"Track with id {request.Id} was not found!");

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync(cancellationToken);
            return track;
        }

    }
}
