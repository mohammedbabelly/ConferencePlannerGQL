using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Sessions.Queries.GetSession {

    public record GetSessionQuery(int Id) : IRequest<Session> { }

    public class GetSessionsQueryHandler : IRequestHandler<GetSessionQuery, Session> {
        private readonly IApplicationDbContext _context;


        public GetSessionsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Session> Handle(GetSessionQuery request, CancellationToken cancellationToken) {
             var session = await _context
                .Sessions
                .FirstOrDefaultAsync(f => f.Id == request.Id);
            if (session == null)
                throw new Exception($"Session with id {request.Id} was not found");
            return session;
        }

    }
}
