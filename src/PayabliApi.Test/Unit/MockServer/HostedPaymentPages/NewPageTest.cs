using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.HostedPaymentPages;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class NewPageTest : BaseMockServerTest
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
              "pageIdentifier": "null",
              "responseCode": 1,
              "responseData": "responseData",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Paypoint/8cfec329267")
                    .WithHeader("idempotencyKey", "6B29FC40-CA47-1067-B31D-00DD010662DA")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.HostedPaymentPages.NewPageAsync(
            "8cfec329267",
            new NewPageRequest
            {
                IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
                Body = new PayabliPages(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
