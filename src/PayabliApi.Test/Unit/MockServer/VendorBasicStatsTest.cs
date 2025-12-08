using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class VendorBasicStatsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "statX": "2023-03",
                "active": 25,
                "activeVolume": 5000.25,
                "sentToApproval": 10,
                "sentToApprovalVolume": 2500.75,
                "toApproval": 8,
                "toApprovalVolume": 1800.5,
                "approved": 20,
                "approvedVolume": 4200,
                "disapproved": 3,
                "disapprovedVolume": 600.25,
                "cancelled": 2,
                "cancelledVolume": 400,
                "inTransit": 5,
                "inTransitVolume": 1250.75,
                "paid": 18,
                "paidVolume": 3800.5
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Statistic/vendorbasic/ytd/m/1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Statistic.VendorBasicStatsAsync(
            "m",
            1,
            "ytd",
            new VendorBasicStatsRequest()
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<IEnumerable<StatisticsVendorQueryRecord>>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
