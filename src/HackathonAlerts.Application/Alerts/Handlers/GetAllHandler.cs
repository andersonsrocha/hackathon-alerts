using AutoMapper;
using HackathonAlerts.Application.Alerts.Queries;
using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Interfaces;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Handlers;

public class GetAllHandler(IAlertRepository repository, IMapper mapper) : IRequestHandler<GetAllRequest, Result<IEnumerable<AlertDto>>>
{
    public async Task<Result<IEnumerable<AlertDto>>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        => Result.Success(mapper.Map<IEnumerable<AlertDto>>(await repository.FindAsync(cancellationToken)));
}