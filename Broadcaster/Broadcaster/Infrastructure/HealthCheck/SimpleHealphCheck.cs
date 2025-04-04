using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Broadcaster.Infrastructure.HealthCheck
{
    public class SimpleHealphCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return new HealthCheckResult(HealthStatus.Healthy);
        }
    }
}
