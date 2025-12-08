using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class VoidTest : BaseMockServerTest
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
                "referenceId": "132-9eab3dfe958146639944aebcab3e9e28",
                "resultCode": 1,
                "resultText": "Transaction Void Successful",
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
                    .WithPath("/MoneyIn/void/10-3ffa27df-b171-44e0-b251-e95fbfc7a723")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.VoidAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<VoidResponse>(mockResponse)).UsingDefaults()
        );
    }
}
