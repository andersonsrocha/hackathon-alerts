using HackathonAlerts.Domain.Interfaces;

namespace HackathonAlerts.Data;

public sealed class UnitOfWork(HackathonAlertsContext context) : IUnitOfWork
{
    public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        => await context.SaveChangesAsync(cancellationToken) > 0;
}