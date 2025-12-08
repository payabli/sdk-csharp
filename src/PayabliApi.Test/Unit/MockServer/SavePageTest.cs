using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class SavePageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": "string",
              "responseText": "Updated"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Paypoint/8cfec329267/pay-your-fees-1")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.HostedPaymentPages.SavePageAsync(
            "8cfec329267",
            "pay-your-fees-1",
            new PayabliPages()
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
