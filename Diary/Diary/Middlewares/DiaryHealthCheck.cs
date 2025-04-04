using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Diary.MiddleWares
{
    public class DiaryHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return new HealthCheckResult(HealthStatus.Healthy);
        }
    }
}
