using System.Text;
using System.Text.Json;
using HackathonAlerts.Domain.Models;
using HackathonAlerts.NewRelicEvent.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HackathonAlerts.NewRelicEvent.Services;

public class NewRelicEventPublisher(HttpClient httpClient, IOptions<NewRelicEventPublisherOptions> options, ILogger<NewRelicEventPublisher> logger) : INewRelicEventPublisher
{
    public async Task PublishAlertEventAsync(Alert alert, CancellationToken cancellationToken)
    {
        logger.LogInformation("Sending alert with id {Guid} to New Relic", alert.Id);
        
        var data = new
        {
            eventType = "Alerts",
            id = alert.Id,
            plotId = alert.PlotId,
            plotName = alert.PlotName,
            status = alert.Status,
            message = alert.Message,
            createdIn = alert.CreatedIn
        };
        var content = new StringContent(
            JsonSerializer.Serialize(data),
            Encoding.UTF8, 
            "application/json"
        );
        var response = await httpClient.PostAsync($"{options.Value.AccountId}/events", content, cancellationToken: cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("Failed to publish alert event with id {Guid} to New Relic. Status code: {StatusCode}", alert.Id, response.StatusCode);
            throw new Exception("Failed to publish alert event to New Relic");
        }

        logger.LogInformation("Alert event with id {Guid} has been published to New Relic", alert.Id);
    }
}