using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Statistic;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubStatsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "interval": "30",
                "count": 23,
                "volume": 1609.62
              },
              {
                "interval": "60",
                "count": 0,
                "volume": 0
              },
              {
                "interval": "90",
                "count": 0,
                "volume": 0
              },
              {
                "interval": "+90",
                "count": 0,
                "volume": 0
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Statistic/subscriptions/all/2/1000000")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.SubStatsAsync("all", 2, 1000000);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
