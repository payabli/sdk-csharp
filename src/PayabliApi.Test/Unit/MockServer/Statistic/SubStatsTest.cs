using NUnit.Framework;
using PayabliApi;
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
                "statX": "2023-03",
                "inTransactions": 150,
                "inTransactionsVolume": 25000.5,
                "inWalletTransactions": 10,
                "inWalletVolume": 1000.5
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Statistic/subscriptions/30/2/1000000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.SubStatsAsync(
            "30",
            2,
            1000000,
            new SubStatsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
