using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksAPI.Health
{
    // Should be placed in Infra layer
    internal sealed  class HealthCheckCustom : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                // Add Custom logic
                // Await something
                return HealthCheckResult.Healthy();
            }
            catch (Exception e)
            {
                return HealthCheckResult.Unhealthy(exception: e);
            }    
        }
    }
}
