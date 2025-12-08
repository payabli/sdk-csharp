using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ConfigureGooglePayPaypointTest : BaseMockServerTest
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
                "walletType": "googlepay",
                "walletData": {
                  "gatewayMerchantId": "123ID",
                  "gatewayId": "123ID"
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
                    .WithPath("/Wallet/googlepay/configure-paypoint")
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

        var response = await Client.Wallet.ConfigureGooglePayPaypointAsync(
            new ConfigurePaypointRequestGooglePay { Entry = "8cfec329267", IsEnabled = true }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ConfigureGooglePaypointApiResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
