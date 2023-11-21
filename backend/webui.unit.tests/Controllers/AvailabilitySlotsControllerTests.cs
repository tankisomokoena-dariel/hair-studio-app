using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Queries;
using backend.Application.Common.Models;
using backend.Domain.Entities;
using FizzWare.NBuilder;
using Moq;
using WebUI.Controllers;

namespace WebUi.UnitTests.Controllers;
[TestClass]
public class AvailabilitySlotsControllerTests : BaseControllerTests<AvailabilitySlotsController>
{
    public override AvailabilitySlotsController InitilizeController()
    {
        return new AvailabilitySlotsController(AvailabilitySlotServieceMock.Object);
    }

    [TestMethod]
    public async Task GetAvailabilitySlots_GivenSuccess_ShouldReturnAvailabilitySlots()
    {
        //Arrange: Set up the test.

        var param = new GetAvailabilitySlotsQuery();

        var result = Builder<AvailabilitySlotDTO>
            .CreateListOfSize(1)
            .Build();

        AvailabilitySlotServieceMock.Setup(x => x.GetAvailabilitySlots(param))
            .ReturnsAsync(result)
            .Verifiable();

        //Act: Execute the test.
        var sut = await Controller.Get();

        //Assert: Verify the results.
        Assert.IsNotNull(sut);
        Assert.AreEqual(result.Count, sut.Count());
    }

    [TestMethod]
    public async Task AddAvailabilitySlots_GivenSuccess_ShouldReturnSuccess()
    {
        //Arrange: Set up the test.
        var param = Builder<AvailabilitySlot>
            .CreateNew() 
            .Build();

        var result = new Result
        {
            Succeeded = true

        };

        AvailabilitySlotServieceMock.Setup(x => x.AddAvailabilitySlots(param))
            .ReturnsAsync(result)
            .Verifiable();

        //Act: Execute the test.
        var sut = await Controller.AddAvailabilitySlots(param);

        //Assert: Verify the results.
        Assert.IsNotNull(sut);

    }

    [TestMethod]
    public async Task UpdateAvailabilitySlot_GivenValidPayload_ShouldReturnSuccess()
    {
        var param = Builder<AvailabilitySlotDTO>
            .CreateNew()
            .Build();

        var result = new Result
        {
            Succeeded = true
        };

        AvailabilitySlotServieceMock.Setup(x => x.UpdateAvailabilitySlots(param))
            .ReturnsAsync(result)
            .Verifiable();

        var sut = await Controller.UpdateAvailabilitySlot(param);

        Assert.IsNotNull(sut);
    }

}

