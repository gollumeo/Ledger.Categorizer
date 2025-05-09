using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Ledger.Categorizer.Tests.Api;

public class TransactionEndpointsTest
{
    [Fact]
    public async Task PostEndpointReturnsCategory()
    {
        var app = new WebApplicationFactory<Program>();
        var client = app.CreateClient();

        const string json = """
                            {
                                "description": "Uber Eats Paris",
                                "amount": 29.90,
                                "date": "2025-05-08T12:45:00Z"
                            }
                            """;

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/transactions", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}