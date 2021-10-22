using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Tracks.Queries.GetTracks {

    public class GetTracksQuery : IRequest<List<Track>> { }

    public class QueryQueryHandler : IRequestHandler<GetTracksQuery, List<Track>> {
        private readonly IApplicationDbContext _context;


        public QueryQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Track>> Handle(GetTracksQuery request, CancellationToken cancellationToken) {
            return await _context.Tracks
                //.Include(f=>f.Sessions)
                .ToListAsync(cancellationToken); 
        }

    }
}
