using ConferencePlanner.Entities;
using ConferencePlanner.REST.Sessions.Queries.GetSessions;
using GraphQL.Types;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL.Types {
    public class TrackType : ObjectGraphType<Track> {
        public TrackType(ISender mediator) {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id property from the track object.");
            Field(f => f.Name).Description("Track name.");
            FieldAsync<ListGraphType<SessionType>>(
                "sessions",
                resolve: async context => await mediator.Send(new GetSessionsQuery(context.Source.Id))
            );

        }
    }
}
