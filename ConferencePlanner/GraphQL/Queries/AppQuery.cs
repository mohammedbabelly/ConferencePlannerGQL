using ConferencePlanner.GraphQL.Types;
using ConferencePlanner.REST.Sessions.Queries.GetSession;
using ConferencePlanner.REST.Tracks.Queries.GetTracks;
using GraphQL.Types;
using MediatR;
using GraphQL;
using System;

namespace ConferencePlanner.GraphQL.Queries {
    public class AppQuery : ObjectGraphType {
        public AppQuery(ISender mediator) {
            FieldAsync<ListGraphType<TrackType>>(
                "tracks",
                resolve: async context => await mediator.Send(new GetTracksQuery()),
                description: "Get all tracks with sessions"
           );
            FieldAsync<SessionType>(
                "session",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "sessionId" }),
                resolve: async context => {
                    try {
                        int id = context.GetArgument<int>("sessionId");
                        return await mediator.Send(new GetSessionQuery(id));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                });
        }
    }
}
