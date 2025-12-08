using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CaptureTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/capture/10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13/0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.CaptureAsync(
            "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
            0
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureResponse>(mockResponse)).UsingDefaults()
        );
    }
}
