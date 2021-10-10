using ConferencePlanner.Entities;

namespace ConferencePlanner.GraphQL.Models.AddSpeaker {
    public class AddSpeakerPayload {
        public AddSpeakerPayload(Speaker speaker) {
            Speaker = speaker;
        }

        public Speaker Speaker { get; }
    }
}
