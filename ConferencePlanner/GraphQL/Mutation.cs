using ConferencePlanner.Entities;
using HotChocolate;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.Models.AddTrack;
using MediatR;
using ConferencePlanner.REST.Tracks.Commands.Add;
using ConferencePlanner.REST.Sessions.Commands.Add;

namespace ConferencePlanner.GraphQL {
    public class Mutation {
        #region Tracks

        public async Task<Track> AddTrack(AddTrackInput input, [Service] ISender mediator) => await mediator.Send(new AddTrackCommand(input.Name));
        #endregion

        #region Sessions

        public async Task<Session> AddSession(AddSessionInput input, [Service] ISender mediator) 
            => await mediator.Send(new AddSessionCommand(input));
        #endregion

    }
}
