using Microsoft.EntityFrameworkCore;
using HackathonAlerts.Domain.Models;
using MongoDB.EntityFrameworkCore.Extensions;

namespace HackathonAlerts.Data;

public class HackathonAlertsContext(DbContextOptions<HackathonAlertsContext> options) : DbContext(options)
{
    public DbSet<Alert> Alerts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(HackathonAlertsContext).Assembly);
        builder.Entity<Alert>().ToCollection("alerts");
    }
}