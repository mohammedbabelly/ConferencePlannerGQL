﻿using ConferencePlanner.Data;
using ConferencePlanner.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ConferencePlanner.REST.Sessions.Queries.GetSession {

    public record GetSessionQuery(int id) : IRequest<Session> { }

    public class GetSessionsQueryHandler : IRequestHandler<GetSessionQuery, Session> {
        private readonly IApplicationDbContext _context;


        public GetSessionsQueryHandler(IApplicationDbContext context) {
            _context = context;
        }

        public async Task<Session> Handle(GetSessionQuery request, CancellationToken cancellationToken) {
            return await _context
                .Sessions
                //.Include(f => f.Attendees)
                .FirstOrDefaultAsync(f => f.Id == request.id);
        }

    }
}
