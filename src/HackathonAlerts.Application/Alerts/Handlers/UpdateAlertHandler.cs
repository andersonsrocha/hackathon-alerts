using AutoMapper;
using HackathonAlerts.Application.Alerts.Commands;
using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Handlers;

public class UpdateAlertHandler(IAlertRepository repository, IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateAlertHandler> logger) : IRequestHandler<UpdateAlertRequest, Result<AlertDto>>
{
    public async Task<Result<AlertDto>> Handle(UpdateAlertRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating a alert with id: {Id}", request.Id);
        
        logger.LogInformation("Checking if alert with id {Id} exists", request.Id);
        var alert = await repository.FindAsync(request.Id, cancellationToken);
        if (alert is null)
            return Result.Error<AlertDto>(new Exception("Alert not found"));
        
        alert.Update(request.Status, request.Message);
        repository.Update(alert);
        await unitOfWork.CommitAsync(cancellationToken);
        
        logger.LogInformation("Alert updated successfully.");
        return Result.Success(mapper.Map<AlertDto>(alert));
    }
}