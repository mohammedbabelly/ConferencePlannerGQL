using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Sessions.Queries.GetSessions {

    public record GetSessionsQuery(int trackId) : IRequest<List<Session>> { }

    public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, List<Session>> {
        private readonly IApplicationDbContext _context;


        public GetSessionsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Session>> Handle(GetSessionsQuery request, CancellationToken cancellationToken) {
            var res = await _context.Sessions
                .Where(f => f.TrackId == request.trackId)
                .ToListAsync(cancellationToken);
            return res;
        }
    }
}
