using ConferencePlanner.Entities;
using GraphQL.Types;
namespace ConferencePlanner.GraphQL.Types {
    public class AttendeeType : ObjectGraphType<Attendee> {
        public AttendeeType() {
            Field(f => f.Id, type: typeof(IdGraphType)).Description("Session Id");
            Field(f => f.Name, type: typeof(StringGraphType)).Description("Attendee Name");
            Field(f => f.Email, type: typeof(StringGraphType)).Description("Attendee Email");
        }
    }
}
