using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class UpdatePaymentMethodDomainTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "applePay": {
                "isEnabled": false
              },
              "googlePay": {
                "isEnabled": false
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageidentifier": "null",
              "responseData": {
                "id": "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
                "type": "PaymentMethodDomains",
                "entityId": 78,
                "entityType": "organization",
                "domainName": "checkout.example.com",
                "applePay": {
                  "isEnabled": false,
                  "data": null
                },
                "googlePay": {
                  "isEnabled": false,
                  "data": null
                },
                "ownerEntityId": 78,
                "ownerEntityType": "organization",
                "cascades": [
                  {
                    "jobId": "1245697",
                    "jobStatus": "completed",
                    "jobErrorMessage": null,
                    "createdAt": "2025-04-25T15:37:28.685Z",
                    "updatedAt": "2025-04-25T15:37:33.228Z"
                  }
                ],
                "createdAt": "2025-03-15T10:24:36.207Z",
                "updatedAt": "2025-04-25T16:05:12.345Z"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/pmd_b8237fa45c964d8a9ef27160cd42b8c5")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.UpdatePaymentMethodDomainAsync(
            "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
            new UpdatePaymentMethodDomainRequest
            {
                ApplePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
                GooglePay = new UpdatePaymentMethodDomainRequestWallet { IsEnabled = false },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
