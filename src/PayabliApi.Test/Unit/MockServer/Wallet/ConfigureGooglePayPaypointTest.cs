using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Wallet;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "responseText": "Success"
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
