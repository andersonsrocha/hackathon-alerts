using HackathonAlerts.Domain.Dto;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Queries;

public sealed class GetByIdRequest(Guid id) : IRequest<Result<AlertDto>>
{
    public Guid Id { get; init; } = id;
}