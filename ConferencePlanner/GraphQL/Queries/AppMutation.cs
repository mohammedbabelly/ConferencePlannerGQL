using ConferencePlanner.Entities;
using ConferencePlanner.GraphQL.Types;
using ConferencePlanner.GraphQL.Types.Inputs;
using ConferencePlanner.REST.Attendees.Commands;
using ConferencePlanner.REST.Sessions.Commands.Add;
using ConferencePlanner.REST.Sessions.Commands.Delete;
using ConferencePlanner.REST.Sessions.Commands.Update;
using ConferencePlanner.REST.Tracks.Commands.Add;
using ConferencePlanner.REST.Tracks.Commands.Delete;
using ConferencePlanner.REST.Tracks.Commands.Update;
using GraphQL;
using GraphQL.Types;
using MediatR;
using System;

namespace ConferencePlanner.GraphQL.Queries {
    public class AppMutation : ObjectGraphType {
        public AppMutation(ISender mediator) {
            #region Tracks

            FieldAsync<TrackType>(
                "createTrack",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<TrackInputType>> { Name = "track" }),
                resolve: async context => {
                    var track = context.GetArgument<Track>("track");
                    return await mediator.Send(new AddTrackCommand(track.Name));
                }
            );
            FieldAsync<TrackType>(
                "updateTrack",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "trackId" },
                    new QueryArgument<NonNullGraphType<TrackInputType>> { Name = "newTrack" }
                 ),
                resolve: async context => {
                    try {
                        var trackId = context.GetArgument<int>("trackId");
                        var track = context.GetArgument<Track>("newTrack");
                        return await mediator.Send(new UpdateTrackCommand(track.Name, trackId));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );
            FieldAsync<TrackType>(
                "deleteTrack",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "trackId" }),
                resolve: async context => {
                    try {
                        var trackId = context.GetArgument<int>("trackId");
                        return await mediator.Send(new DeleteTrackCommand(trackId));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );
            #endregion

            #region Sessions
            FieldAsync<SessionType>(
                "createSession",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<SessionInputType>> { Name = "session" }),
                resolve: async context => {
                    try {
                        var sessionInput = context.GetArgument<AddSessionInput>("session");
                        return await mediator.Send(new AddSessionCommand(sessionInput));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );

            FieldAsync<SessionType>(
                "deleteSession",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "sessionId" }),
                resolve: async context => {
                    try {
                        var sessionId = context.GetArgument<int>("sessionId");
                        return await mediator.Send(new DeleteSessionCommand(sessionId));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );
            FieldAsync<SessionType>(
                "updateSession",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "sessionId" },
                    new QueryArgument<NonNullGraphType<SessionInputType>> { Name = "newSession" }
                 ),
                resolve: async context => {
                    try {
                        var sessionId = context.GetArgument<int>("sessionId");
                        var session = context.GetArgument<AddSessionInput>("newSession");
                        return await mediator.Send(new UpdateSessionCommand(session, sessionId));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );
            FieldAsync<AttendeeType>(
                "registerAttendee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "sessionId" },
                    new QueryArgument<NonNullGraphType<AttendeeInputType>> { Name = "attendee" }
                 ),
                resolve: async context => {
                    try {
                        var sessionId = context.GetArgument<int>("sessionId");
                        var attendee = context.GetArgument<Attendee>("attendee");
                        return await mediator.Send(new RegisterAttendeeCommand(sessionId, attendee));
                    } catch (Exception e) {
                        throw new ExecutionError(e.Message);
                    }
                }
            );
            #endregion
        }
    }
}
