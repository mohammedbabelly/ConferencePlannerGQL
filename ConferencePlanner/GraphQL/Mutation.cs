using ConferencePlanner.Data;
using ConferencePlanner.GraphQL.Models.AddSpeaker;
using ConferencePlanner.GraphQL.Extentions;
using ConferencePlanner.GraphQL.Entities;
using HotChocolate;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConferencePlanner.GraphQL.Models.AddTrack;

namespace ConferencePlanner.GraphQL {
    public class Mutation {
        [UseApplicationDbContext]
        public async Task<AddSpeakerPayload> AddSpeakerAsync(AddSpeakerInput input, [ScopedService] ApplicationDbContext context) {
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
        public async Task<AddSpeakerPayload> AddSessionAsync(AddSpeakerInput input, [ScopedService] ApplicationDbContext context) {
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
        public async Task<Track> AddTrackAsync(AddTrackInput input, [ScopedService] ApplicationDbContext context) {
            var track = new Track { Name = input.Name, Sessions = new List<Session>() };
            context.Tracks.Add(track);
            await context.SaveChangesAsync();

            return track;
        }
    }
}
