using ConferencePlanner.Entities;
using ConferencePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Types.Inputs;
using ConferencePlanner.REST.Tracks.Commands.Add;
using ConferencePlanner.REST.Tracks.Commands.Update;
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
            FieldAsync<TrackType>(
                "updateTrack",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "trackId" },
                    new QueryArgument<NonNullGraphType<TrackInputType>> { Name = "newTrack" }
                 ),
                resolve: async context => {
                    var trackId = context.GetArgument<int>("trackId");
                    var track = context.GetArgument<Track>("newTrack");
                    return await mediator.Send(new UpdateTrackCommand(track.Name, trackId));
                }
            );
        }
    }
}
