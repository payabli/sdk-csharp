using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
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
                    .WithPath("/Statistic/subscriptions/30/1/1000000")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.SubStatsAsync(
            1000000,
            "30",
            1,
            new SubStatsRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<IEnumerable<StatBasicQueryRecord>>(mockResponse))
                .UsingDefaults()
        );
    }
}
