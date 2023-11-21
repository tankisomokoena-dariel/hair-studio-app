using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Dto;
using backend.Application.AvailabilitySlots.Interfaces;
using backend.Application.AvailabilitySlots.Queries;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Extensions;
using MediatR;
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
        var param = Builder<GetAvailabilitySlotsQuery>
            .CreateNew()
            .Build();

        var result = Builder<AvailabilitySlotDTO>
            .CreateListOfSize(1)
            .Build();

        AvailabilitySlotServieceMock.Setup(x => x.GetAvailabilitySlots(param))
            .Returns((Task<List<AvailabilitySlotDTO>>)result)
            .Verifiable();

        var sut = await Controller.Get();

        Assert.IsNotNull(sut);
    }
}

