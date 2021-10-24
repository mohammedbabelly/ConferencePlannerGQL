using ConferencePlanner.GraphQL.Types;
using ConferencePlanner.REST.Sessions.Queries.GetSession;
using ConferencePlanner.REST.Tracks.Queries.GetTracks;
using GraphQL.Types;
using MediatR;
using GraphQL;

namespace ConferencePlanner.GraphQL.Queries {
    public class AppQuery : ObjectGraphType {
        public AppQuery(ISender mediator) {
            FieldAsync<ListGraphType<TrackType>>(
                "tracks",
                resolve: async context => await mediator.Send(new GetTracksQuery())
           );
            FieldAsync<SessionType>(
                "session",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "sessionId" }),
                resolve: async context => {
                    int id = context.GetArgument<int>("sessionId");
                    if (id == 0) {
                        context.Errors.Add(new ExecutionError("Wrong value for session id"));
                        return null;
                    }
                    return await mediator.Send(new GetSessionQuery(id));
                });
        }
    }
}
