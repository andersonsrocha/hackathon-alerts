namespace HackathonAlerts.Domain.Dto;

public record AlertDto(Guid Id, bool Active, Guid PlotId, string Status, string Message);