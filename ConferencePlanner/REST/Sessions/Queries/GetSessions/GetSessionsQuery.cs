using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Sessions.Queries.GetSessions {

    public class GetSessionsQuery : IRequest<List<Session>> { }

    public class GetSessionsQueryHandler : IRequestHandler<GetSessionsQuery, List<Session>> {
        private readonly IApplicationDbContext _context;


        public GetSessionsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Session>> Handle(GetSessionsQuery request, CancellationToken cancellationToken) {
            return await _context.Sessions
                //.Include(f => f.Attendees)
                .ToListAsync(cancellationToken);
        }
    }
}
