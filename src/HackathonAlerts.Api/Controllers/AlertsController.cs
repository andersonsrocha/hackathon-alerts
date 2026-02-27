using HackathonAlerts.Application.Alerts.Commands;
using HackathonAlerts.Application.Alerts.Queries;
using HackathonAlerts.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackathonAlerts.Api.Controllers;

[Route("api/[controller]")]
public class AlertsController(ILogger<AlertsController> logger, IMediator mediator) : BaseController(logger)
{
    [HttpGet]
    [Authorize("Admin")]
    [Route("{id:Guid}")]
    [ProducesResponseType(typeof(AlertDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
        => await Send(mediator.Send(new GetByIdRequest(id)));
    
    [HttpGet]
    [Authorize("Admin")]
    [ProducesResponseType(typeof(AlertDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
        => await Send(mediator.Send(new GetAllRequest()));
    
    [HttpPost]
    [Authorize("Admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CreateAlertRequest request)
        => await Send(mediator.Send(request));
    
    [HttpPut]
    [Authorize("Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromBody] UpdateAlertRequest request)
        => await Send(mediator.Send(request));
}