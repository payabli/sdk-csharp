using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CustomerBasicStatsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "interval": "2023-03",
                "count": 45,
                "volume": 12500.75
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Statistic/customerbasic/ytd/m/998")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.CustomerBasicStatsAsync(
            998,
            "m",
            "ytd",
            new CustomerBasicStatsRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<IEnumerable<SubscriptionStatsQueryRecord>>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
