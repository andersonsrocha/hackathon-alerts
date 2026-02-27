using HackathonAlerts.Domain.Interfaces;
using HackathonAlerts.Domain.Models;

namespace HackathonAlerts.Data.Repositories;

public class AlertRepository(HackathonAlertsContext context) : Repository<Alert>(context), IAlertRepository;