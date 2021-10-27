using ConferencePlanner.GraphQL.Queries;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace ConferencePlanner.GraphQL.Schemas {
    public class AppSchema : Schema {
        public AppSchema(IServiceProvider provider) : base(provider) {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
