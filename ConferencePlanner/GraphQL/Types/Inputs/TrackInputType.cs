using GraphQL.Types;

namespace ConferencePlanner.GraphQL.Types.Inputs {
    public class TrackInputType : InputObjectGraphType {
        public TrackInputType() {
            Name = "TrackInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
