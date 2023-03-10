using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;
// using CarsApi.Services.Health;

namespace CarsApi.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var url = "https://airport-info.p.rapidapi.com/airport";

        var client = new RestClient();

        var request = new RestRequest(url, Method.Get);

        request.AddHeader("X-RapidAPI-Key", "fa8946b5e6msh517be52504e13e6p189bd2jsn06062a93600d");
        request.AddHeader("X-RapidAPI-Host", "airport-info.p.rapidapi.com");

        var response = client.Execute(request);

        if(response.IsSuccessful)
            return Task.FromResult(HealthCheckResult.Healthy());
        else
            return Task.FromResult(HealthCheckResult.Unhealthy());    

    }
}