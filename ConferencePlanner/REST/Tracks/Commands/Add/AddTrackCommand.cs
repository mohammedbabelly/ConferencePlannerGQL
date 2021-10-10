﻿using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Tracks.Commands.Add {

    public record AddTrackCommand(string Name) : IRequest<Unit> { }

    public class AddTrackCommandHandler : IRequestHandler<AddTrackCommand, Unit> {
        private readonly IApplicationDbContext _context;

        public AddTrackCommandHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Unit> Handle(AddTrackCommand request, CancellationToken cancellationToken) {
            var track = new Track { Name = request.Name };
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
