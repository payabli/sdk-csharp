using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class RemovePageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Paypoint/8cfec329267/pay-your-fees-1")
                    .UsingDelete()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Paypoint.RemovePageAsync("8cfec329267", "pay-your-fees-1");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseGeneric2Part>(mockResponse))
                .UsingDefaults()
        );
    }
}
