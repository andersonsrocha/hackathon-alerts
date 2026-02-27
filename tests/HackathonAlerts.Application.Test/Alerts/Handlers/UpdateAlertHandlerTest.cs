using AutoMapper;
using HackathonAlerts.Application.Alerts.Commands;
using HackathonAlerts.Application.Alerts.Handlers;
using HackathonAlerts.Domain.Interfaces;
using HackathonAlerts.Domain.Models;
using Microsoft.Extensions.Logging;
using Moq;

namespace HackathonAlerts.Application.Test.Alerts.Handlers;

public class UpdateAlertHandlerTest
{
    private readonly Mock<IAlertRepository> _repository = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();
    private readonly Mock<IMapper> _mapper = new();
    private readonly Mock<ILogger<UpdateAlertHandler>> _logger = new();
    private readonly UpdateAlertHandler _handler;
    
    public UpdateAlertHandlerTest()
        => _handler = new UpdateAlertHandler(_repository.Object, _unitOfWork.Object, _mapper.Object, _logger.Object);
    
    [Fact]
    public async Task Handle_WhenAlertNotFound_ShouldReturnError()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var request = new UpdateAlertRequest
        {
            Id = alertId,
            Message = "Test Alert",
            Status = "Test Status"
        };
        _repository.Setup(x => x.FindAsync(alertId, CancellationToken.None)).Returns(Task.FromResult<Alert?>(null));
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Alert not found", result.Exception.Message);
    }
    
    [Fact]
    public async Task Handle_WhenValid_ShouldReturnSuccess()
    {
        // Arrange
        var alertId = Guid.NewGuid();
        var request = new UpdateAlertRequest
        {
            Id = alertId,
            Message = "Test Alert",
            Status = "Test Status"
        };
        _repository.Setup(x => x.FindAsync(alertId, CancellationToken.None)).Returns(Task.FromResult<Alert?>(new Alert()));
        
        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        _repository.Verify(x => x.Update(It.IsAny<Alert>()), Times.Once);
    }
}