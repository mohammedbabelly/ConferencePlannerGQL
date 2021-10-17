using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Models.AddSpeaker;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.Entities;
using HotChocolate;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConferencePlanner.GraphQL.Models.AddTrack;
using MediatR;
using ConferencePlanner.REST.Tracks.Commands.Add;

namespace ConferencePlanner.GraphQL {
    public class Mutation {
        #region Tracks

        public async Task<Track> AddTrack(AddTrackInput input, [Service] ISender mediator) => await mediator.Send(new AddTrackCommand(input.Name));
        #endregion
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeaker(AddSpeakerInput input, [ScopedService] ApplicationDbContext context) {
            var speaker = new Speaker {
                Name = input.Name,
                Bio = input.Bio,
                Website = input.Website
            };
            context.Speakers.Add(speaker);
            await context.SaveChangesAsync();

            return new AddSpeakerPayload(speaker);
        }

        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSession(AddSpeakerInput input, [ScopedService] ApplicationDbContext context) {
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
