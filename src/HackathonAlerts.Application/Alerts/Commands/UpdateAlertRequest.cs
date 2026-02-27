using HackathonAlerts.Domain.Dto;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Commands;

public sealed class UpdateAlertRequest : IRequest<Result<AlertDto>>
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}