using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.GraphQL.Entities;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL {
    public class Query {
        [GraphQLDescription("A query field")]
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();
    }
}
