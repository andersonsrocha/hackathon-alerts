using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Models;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Commands;

public sealed class CreateAlertRequest : IRequest<Result<AlertDto>>
{
    public Guid PlotId { get; set; } = Guid.Empty;
    public string PlotName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    
    public static implicit operator Alert(CreateAlertRequest request)
        => new(request.PlotId, request.PlotName, request.Status, request.Message);
}