using AutoMapper;
using HackathonAlerts.Application.Alerts.Queries;
using HackathonAlerts.Domain.Dto;
using HackathonAlerts.Domain.Interfaces;
using MediatR;
using OperationResult;

namespace HackathonAlerts.Application.Alerts.Handlers;

public class GetByIdHandler(IAlertRepository repository, IMapper mapper) : IRequestHandler<GetByIdRequest, Result<AlertDto>>
{
    public async Task<Result<AlertDto>> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        => Result.Success(mapper.Map<AlertDto>(await repository.FindAsync(request.Id, cancellationToken)));
}