using GraphQL.Types;

namespace ConferencePlanner.GraphQL.Types.Inputs {
    public class SessionInputType : InputObjectGraphType {
        public SessionInputType() {
            Name = "SessionInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("StartTime");
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("EndTime");
            Field<NonNullGraphType<IntGraphType>>("trackId");
        }
    }
}