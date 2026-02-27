namespace HackathonAlerts.Domain.Models;

public sealed class Alert : Entity
{
    public Alert() { }

    public Alert(Guid plotId, string plotName, string status, string message)
    {
        PlotId = plotId;
        PlotName = plotName;
        Status = status;
        Message = message;
    }

    public Guid PlotId { get; set; } = Guid.Empty;
    public string PlotName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    
    public void Update(string status, string message)
    {
        Status = status;
        Message = message;
    }
}