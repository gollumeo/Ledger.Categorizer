using System.Net;
using System.Text;
using System.Text.Json;
using Ledger.Categorizer.Presentation.Dto;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Ledger.Categorizer.Tests.Api;

public class TransactionEndpointsTest
{
    [Theory]
    [InlineData("Uber Eats Paris", 29.90, "2025-05-08T12:45:00Z")]
    [InlineData("Uber Eats Brussels", 37.42, "2025-05-08T12:45:00Z")]
    [InlineData("Uber Hamburg", 75.00, "2025-05-08T12:45:00Z")]
    [InlineData("Rental", 1200.47, "2025-05-08T12:45:00Z")]
    [InlineData("Aldi", 45.60, "2025-05-08T12:45:00Z")]
    public async Task PostEndpointReturnsCategory(string description, decimal amount, string date)
    {
        var app = new WebApplicationFactory<Program>();

        var client = app.CreateClient();

        var request = new CategorizeRequest
        {
            Description = description,
            Amount = amount,
            Date = DateTime.Parse(date)
        };

        var json = JsonSerializer.Serialize(request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/categorize", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        ;
    }
}