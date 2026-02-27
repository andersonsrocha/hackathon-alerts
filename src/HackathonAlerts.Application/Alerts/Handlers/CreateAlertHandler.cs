using AutoMapper;
using HackathonAlerts.Application.Alerts.Commands;
using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Interfaces;
using HackathonAlerts.Domain.Models;
using HackathonAlerts.NewRelicEvent.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Handlers;

public class CreateAlertHandler(IAlertRepository repository, INewRelicEventPublisher publisher, IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateAlertHandler> logger) : IRequestHandler<CreateAlertRequest, Result<AlertDto>>
{
    public async Task<Result<AlertDto>> Handle(CreateAlertRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new alert with plot: {PlotId}", request.PlotId);

        var alert = (Alert)request;
        repository.Add(alert);
        
        logger.LogInformation("Sending alert with id {Guid} to New Relic", alert.Id);
        await publisher.PublishAlertEventAsync(alert, cancellationToken);
        
        logger.LogInformation("Committing the transaction to the database");
        await unitOfWork.CommitAsync(cancellationToken);
        
        logger.LogInformation("Alert created successfully.");
        return Result.Success(mapper.Map<AlertDto>(alert));
    }
}