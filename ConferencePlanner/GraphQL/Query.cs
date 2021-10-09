using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.GraphQL.Entities;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConferencePlanner.GraphQL.DataLoader;
using System.Threading;

namespace ConferencePlanner.GraphQL {
    public class Query {
        [GraphQLDescription("Get all speakers")]
        [UseApplicationDbContext]
        public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
            context.Speakers.ToListAsync();
        [GraphQLDescription("Get speaker by id")]
        public Task<Speaker> GetSpeakerAsync(int id, SpeakerByIdDataLoader dataLoader, CancellationToken cancellationToken) {
            return dataLoader.LoadAsync(id, cancellationToken);
        }
    }
}
