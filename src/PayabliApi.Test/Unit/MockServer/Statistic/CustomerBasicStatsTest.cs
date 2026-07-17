using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Statistic;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithPath("/Statistic/customerbasic/ytd/m/4440")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.CustomerBasicStatsAsync(
            "ytd",
            "m",
            4440,
            new CustomerBasicStatsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
