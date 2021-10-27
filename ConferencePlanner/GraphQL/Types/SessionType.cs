using ConferencePlanner.Entities;
using GraphQL.Types;

namespace ConferencePlanner.GraphQL.Types {
    public class SessionType : ObjectGraphType<Session> {
        public SessionType() {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Session Id");
            Field(f => f.Title).Description("Session Title");
            Field(f => f.Description).Description("Session Description");
            Field(f => f.StartTime, type: typeof(DateTimeOffsetGraphType)).Description("Session StartTime");
            Field(f => f.EndTime, type: typeof(DateTimeOffsetGraphType)).Description("Session EndTime");
            Field<SessionTypeEnumType>("Type", "Session Type");
            Field(f => f.TrackId, type: typeof(IdGraphType)).Description("Session TrackId");
        }
    }
    public class SessionTypeEnumType : EnumerationGraphType<SessionAttendType> {
        public SessionTypeEnumType() {
            Name = "Type";
            Description = "SessionType enum value";
        }
    }
}
