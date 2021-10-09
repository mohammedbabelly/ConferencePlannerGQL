using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Models;
using HotChocolate;
using System.Linq;

namespace ConferencePlanner.GraphQL {
    public class Query {
        [GraphQLDescription("A query field")]
        public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) {
            return context.Speakers;
        }
    }
}
