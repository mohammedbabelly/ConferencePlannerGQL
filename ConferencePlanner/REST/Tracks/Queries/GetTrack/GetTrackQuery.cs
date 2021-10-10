using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Tracks.Queries.GetTrack {

    public record GetTrackQuery(int Id) : IRequest<Track> { }

    public class GetTrackQueryHandler : IRequestHandler<GetTrackQuery, Track> {
        private readonly IApplicationDbContext _context;


        public GetTrackQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Track> Handle(GetTrackQuery request, CancellationToken cancellationToken) {
            return await _context
                .Tracks
                .FirstOrDefaultAsync(f => f.Id == request.Id);
        }

    }
}
