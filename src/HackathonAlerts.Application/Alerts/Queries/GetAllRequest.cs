using HackathonAlerts.Domain.Dto;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Queries;

public sealed class GetAllRequest : IRequest<Result<IEnumerable<AlertDto>>>;