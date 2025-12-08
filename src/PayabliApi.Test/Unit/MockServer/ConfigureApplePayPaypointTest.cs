using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ConfigureApplePayPaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "entry": "8cfec329267",
              "isEnabled": true
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseCode": 1,
              "responseData": {
                "entry": "8cfec329267",
                "isEnabled": true,
                "walletType": "applepay",
                "walletData": {
                  "entry": "8cfec329267",
                  "applePayMerchantId": "applePayMerchantId",
                  "domainNames": [
                    "subdomain.domain.com"
                  ],
                  "paypointName": "Alaskan Domes",
                  "paypointUrl": null,
                  "markedForDeletionAt": "2022-07-01T15:00:01.000Z",
                  "createdAt": "2022-07-01T15:00:01.000Z",
                  "updatedAt": "2022-07-01T15:00:01.000Z",
                  "id": "id",
                  "type": "ApplePayRegistration"
                }
              },
              "responseText": "Success",
              "roomId": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Wallet/applepay/configure-paypoint")
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

        var response = await Client.Wallet.ConfigureApplePayPaypointAsync(
            new ConfigurePaypointRequestApplePay { Entry = "8cfec329267", IsEnabled = true }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ConfigureApplePaypointApiResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
