using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using backend.Application.AvailabilitySlots.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace WebUi.UnitTests.Controllers;
public abstract class BaseControllerTests<TController>
{
    protected TController Controller;
    protected Mock<ILogger<TController>> LoggerMock;
    protected Mock<IAvailabilitySlotService> AvailabilitySlotServieceMock;

    public void SetupMocks()
    {
        LoggerMock = new Mock<ILogger<TController>>();
        AvailabilitySlotServieceMock = new Mock<IAvailabilitySlotService>();
    }

    [TestInitialize]
    public void ClassInitialize()
    {
        SetupMocks();
        Controller = InitilizeController();
    }

    public abstract TController InitilizeController();

    [TestCleanup]
    public void ClassCleanup()
    {
        LoggerMock.VerifyAll();
        AvailabilitySlotServieceMock.VerifyAll();
    }
}
