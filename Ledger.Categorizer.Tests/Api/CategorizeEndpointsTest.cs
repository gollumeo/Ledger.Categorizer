using System.Net;
using System.Text;
using System.Text.Json;
using Ledger.Categorizer.Domain.ValueObjects;
using Ledger.Categorizer.Presentation.Dto;
using Ledger.Categorizer.Tests.Dto;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Ledger.Categorizer.Tests.Api;

public class CategorizeEndpointsTest
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static TheoryData<TestCategorizeCase> TestCases =>
    [
        new("Uber Eats Paris", 29.90m, "2025-05-08T12:45:00Z", Category.FoodDelivery.ToString()),
        new("Rental", 1200.47m, "2025-05-08T12:45:00Z", Category.HighExpense.ToString()),
        new("Uber Hamburg", 75.00m, "2025-05-08T12:45:00Z", Category.Transport.ToString()),
        new("Carrefour", 52.42m, "2025-05-08T12:45:00Z", Category.Uncategorized.ToString())
    ];

    [Theory]
    [MemberData(nameof(TestCases), MemberType = typeof(CategorizeEndpointsTest))]
    public async Task PostEndpointReturnsCategory(TestCategorizeCase testCase)
    {
        var app = new WebApplicationFactory<Program>();

        var client = app.CreateClient();

        var request = new CategorizeRequest
        {
            Description = testCase.Description,
            Amount = testCase.Amount,
            Date = DateTime.Parse(testCase.Date)
        };

        var json = JsonSerializer.Serialize(request);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/categorize", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        var categorizeResponse = JsonSerializer.Deserialize<CategorizeResponse>(responseBody, JsonOptions);

        Assert.NotNull(categorizeResponse);
        Assert.IsType<CategorizeResponse>(categorizeResponse);

        Assert.Equal(testCase.ExpectedCategory, categorizeResponse.Category);
    }

    [Fact]
    public async Task PostEndpointReturnsBadRequestWhenDescriptionIsEmpty()
    {
        var app = new WebApplicationFactory<Program>();

        var client = app.CreateClient();

        const string json = """
                            {
                                "amount": 100.00,
                                "date": "2025-05-08T12:45:00Z"                            
                            }
                            """;

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/categorize", content);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}