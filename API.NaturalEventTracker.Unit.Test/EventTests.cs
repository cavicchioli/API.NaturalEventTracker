using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Handlers;
using API.NaturalEventTracker.Domain.Interfaces;
using API.NaturalEventTracker.Unit.Test.Helpers;
using API.NaturalEventTracker.Unit.Test.Mocks;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace API.NaturalEventTracker.Unit.Test
{
    public class EventTests
    {
        [Fact(DisplayName = "Return A List Of Events")]
        [Trait("NaturalEventTracker", "Handler: ListEventCommandHandler")]
        public async void ListEventCommandHandler_ReturnAllEvents_MustReturnNotNull()
        {
            var eventFaker = new EventFaker();
            var eventRepository = new Mock<IEventRepository>();

            eventRepository.Setup(r => r.GetAll(new Dictionary<string,string>()))
                .Returns(eventFaker.GetAllMock());

            var listEventCommandHandler = new ListEventCommandHandler(eventRepository.Object, AutoMapperSingleton.Mapper);

            // Act
            var tariffs = await listEventCommandHandler.Handle(
                new ListEventCommand() { }, new CancellationToken());

            // Assert
            Assert.NotNull(tariffs);
        }

        [Fact(DisplayName = "Return An Event by Given Id")]
        [Trait("NaturalEventTracker", "Handler: GetEventByIdCommand")]
        public async void GetEventByIdCommand_ReturnAnEvent_MustReturnNotNull()
        {
            var eventFaker = new EventFaker();
            
            var events = eventFaker.GetAllMock();
            var eventId = events.Result.FirstOrDefault().Id;


            var eventRepository = new Mock<IEventRepository>();

            eventRepository.Setup(r => r.GetById(eventId))
                .Returns(eventFaker.GetByIdMock(eventId));

            var getEventByIdCommandHandler = new GetEventByIdCommandHandler(eventRepository.Object, AutoMapperSingleton.Mapper);

            // Act
            var result = await getEventByIdCommandHandler.Handle(
                new GetEventByIdCommand()
                {
                    Id = eventId
                }, new CancellationToken());

            // Assert
            Assert.NotNull(result);
        }
    }
}
