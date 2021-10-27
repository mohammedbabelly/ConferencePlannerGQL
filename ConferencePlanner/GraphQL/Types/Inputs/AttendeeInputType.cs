using GraphQL.Types;

namespace ConferencePlanner.GraphQL.Types.Inputs {
    public class AttendeeInputType : InputObjectGraphType {
        public AttendeeInputType() {
            Name = "AttendeeInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("email");
        }
    }
}