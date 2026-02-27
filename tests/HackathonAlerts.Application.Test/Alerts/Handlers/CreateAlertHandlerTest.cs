using AutoMapper;
using HackathonAlerts.Application.Alerts.Commands;
using HackathonAlerts.Application.Alerts.Handlers;
using HackathonAlerts.Domain.Interfaces;
using HackathonAlerts.Domain.Models;
using HackathonAlerts.NewRelicEvent.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace HackathonAlerts.Application.Test.Alerts.Handlers;

public class CreateAlertHandlerTest
{
    private readonly Mock<IAlertRepository> _repository = new();
    private readonly Mock<INewRelicEventPublisher> _publisher = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<ILogger<CreateAlertHandler>> _logger = new();
    private readonly CreateAlertHandler _handler;
    
    public CreateAlertHandlerTest()
        => _handler = new CreateAlertHandler(_repository.Object, _publisher.Object, _unitOfWork.Object, _mapper.Object, _logger.Object);
    
    [Fact]
    public async Task Handle_WhenValid_ShouldReturnSuccess()
    {
        // Arrange
        var plotId = Guid.NewGuid();
        var request = new CreateAlertRequest
        {
            PlotId = plotId,
            Message = "Test Alert",
            Status = "Test Status",
            PlotName = "Test Plot",
        };
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        _publisher.Verify(x => x.PublishAlertEventAsync(It.IsAny<Alert>(), It.IsAny<CancellationToken>()), Times.Once);
        _repository.Verify(x => x.Add(It.IsAny<Alert>()), Times.Once);
    }
}