using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class BasicStatsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "outCustomers": 18196,
                "outNewCustomers": 1089,
                "outTransactions": 3319,
                "outSubscriptionsPaid": 0,
                "outCardTransactions": 0,
                "outVCardTransactions": 0,
                "outACHTransactions": 0,
                "outCheckTransactions": 0,
                "outPendingMethodTransactions": 22,
                "outTransactionsVolume": 13111741.78,
                "outSubscriptionsPaidVolume": 0,
                "outCardVolume": 0,
                "outVCardVolume": 0,
                "outACHVolume": 0,
                "outCheckVolume": 0,
                "outPendingMethodVolume": 82,
                "statX": "2025-11",
                "inTransactions": 168204,
                "inSubscriptionsPaid": 311,
                "inCustomers": 2561522,
                "inNewCustomers": 44846,
                "inCardTransactions": 115059,
                "inACHTransactions": 53153,
                "inCheckTransactions": 0,
                "inCashTransactions": 15,
                "inWalletTransactions": 0,
                "inCardChargeBacks": 17,
                "inACHReturns": 0,
                "inTransactionsVolume": 104795896.94,
                "inSubscriptionsPaidVolume": 81569.32,
                "inCardVolume": 41085285.13,
                "inACHVolume": 63706101.81,
                "inCheckVolume": 0,
                "inCashVolume": 4510,
                "inWalletVolume": 0,
                "inCardChargeBackVolume": 15455.75,
                "inACHReturnsVolume": 0
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Statistic/basic/ytd/m/1/1000000")
                    .WithParam("endDate", "2025-11-01")
                    .WithParam("startDate", "2025-11-30")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.BasicStatsAsync(
            1000000,
            "m",
            1,
            "ytd",
            new BasicStatsRequest { EndDate = "2025-11-01", StartDate = "2025-11-30" }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<IEnumerable<StatBasicExtendedQueryRecord>>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
