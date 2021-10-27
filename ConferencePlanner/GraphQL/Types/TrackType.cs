using ConferencePlanner.Entities;
using GraphQL.Types;
using MediatR;

namespace ConferencePlanner.GraphQL.Types {
    public class TrackType : ObjectGraphType<Track> {
        public TrackType(ISender mediator) {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Id property from the track object.");
            Field(f => f.Name, type: typeof(StringGraphType)).Description("Track name.");
            Field(f => f.Sessions, type: typeof(ListGraphType<SessionType>)).Description("Track sessions.");
        }
    }
}
