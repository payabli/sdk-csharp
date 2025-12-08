using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ConfigureApplePayOrganizationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "cascade": true,
              "isEnabled": true,
              "orgId": 901
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageIdentifier": "null",
              "responseCode": 1,
              "responseData": {
                "createdAt": "2022-07-01T15:00:01.000Z",
                "id": "id",
                "jobId": "445865",
                "jobStatus": "completed",
                "organizationId": 901,
                "type": "type",
                "updatedAt": "2022-07-01T15:00:01.000Z",
                "updates": {
                  "cascade": true,
                  "isEnabled": true
                }
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Wallet/applepay/configure-organization")
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

        var response = await Client.Wallet.ConfigureApplePayOrganizationAsync(
            new ConfigureOrganizationRequestApplePay
            {
                Cascade = true,
                IsEnabled = true,
                OrgId = 901,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<ConfigureApplePayOrganizationApiResponse>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
