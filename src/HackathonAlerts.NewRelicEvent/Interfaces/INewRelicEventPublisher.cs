using HackathonAlerts.Domain.Models;

namespace HackathonAlerts.NewRelicEvent.Interfaces;

public interface INewRelicEventPublisher
{
    Task PublishAlertEventAsync(Alert alert, CancellationToken cancellationToken);
}