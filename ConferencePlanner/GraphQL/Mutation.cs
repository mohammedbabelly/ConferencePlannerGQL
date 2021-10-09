using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.AddSpeaker;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.GraphQL.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace ConferencePlanner.GraphQL {
    public class Mutation {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(AddSpeakerInput input, [Service] ApplicationDbContext context) {
            var speaker = new Speaker {
                Name = input.Name,
                Bio = input.Bio,
                Website = input.Website
            };
            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }
    }
}
