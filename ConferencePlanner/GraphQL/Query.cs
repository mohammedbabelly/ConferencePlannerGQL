using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.Entities;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using ConferencePlanner.REST.Tracks.Queries.GetTracks;
using ConferencePlanner.REST.Tracks.Queries.GetTrack;
using HotChocolate.Data;

namespace ConferencePlanner.GraphQL {
    public class Query {
        #region Tracks

        [GraphQLDescription("Get all tracks")]
        [UseFiltering]
        public async Task<List<Track>> GetTracks([Service] ISender mediator) {
            return await mediator.Send(new GetTracksQuery());
        }

        [GraphQLDescription("Get track by id")]     
        public async Task<Track> GetTrack(int id, [Service] ISender mediator) => await mediator.Send(new GetTrackQuery { Id = id});
        #endregion


        [GraphQLDescription("Get all speakers")]
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();
    }
}
