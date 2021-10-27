using ConferencePlanner.Entities;
using ConferencePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Types.Inputs;
using ConferencePlanner.REST.Tracks.Commands.Add;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace ConferencePlanner.GraphQL.Queries {
    public class AppMutation : ObjectGraphType {
        public AppMutation(ISender mediator) {
            FieldAsync<TrackType>(
                "createTrack",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TrackInputType>> { Name = "track" }),
                resolve: async context => {
                    var track = context.GetArgument<Track>("track");
                    return await mediator.Send(new AddTrackCommand(track.Name));
                }
            );
        }
    }
}
