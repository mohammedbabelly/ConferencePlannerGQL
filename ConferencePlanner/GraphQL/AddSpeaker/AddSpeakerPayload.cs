using ConferencePlanner.GraphQL.Models;

namespace ConferencePlanner.GraphQL.AddSpeaker {
    public class AddSpeakerPayload {
        public AddSpeakerPayload(Speaker speaker) {
            Speaker = speaker;
        }

        public Speaker Speaker { get; }
    }
}
