using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.HostedPaymentPages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
