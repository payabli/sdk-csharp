using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CaptureOutTest : BaseMockServerTest
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
                "authCode": null,
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/capture/129-219")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.CaptureOutAsync("129-219", new CaptureOutRequest());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AuthCapturePayoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
