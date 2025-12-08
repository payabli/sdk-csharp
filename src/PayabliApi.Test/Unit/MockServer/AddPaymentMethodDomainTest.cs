using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddPaymentMethodDomainTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "domainName": "checkout.example.com",
              "entityId": 109,
              "entityType": "paypoint",
              "applePay": {
                "isEnabled": true
              },
              "googlePay": {
                "isEnabled": true
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "pageidentifier": "pageidentifier",
              "responseData": {
                "id": "pmd_a4c7e39d15f24b8c8d6259f174e3d081",
                "type": "PaymentMethodDomains",
                "entityId": 109,
                "entityType": "paypoint",
                "domainName": "checkout.example.com",
                "applePay": {
                  "isEnabled": true,
                  "data": null
                },
                "googlePay": {
                  "isEnabled": true,
                  "data": null
                },
                "ownerEntityId": 109,
                "ownerEntityType": "paypoint",
                "cascades": [
                  {
                    "jobId": "1030398",
                    "jobStatus": "completed",
                    "jobErrorMessage": null,
                    "createdAt": "2025-04-25T15:37:28.685Z",
                    "updatedAt": "2025-04-25T15:37:33.228Z"
                  },
                  {
                    "jobId": "611502",
                    "jobStatus": "completed",
                    "jobErrorMessage": null,
                    "createdAt": "2026-09-26T22:25:45.095Z",
                    "updatedAt": "2026-09-26T22:25:46.187Z"
                  },
                  {
                    "jobId": "611172",
                    "jobStatus": "completed",
                    "jobErrorMessage": null,
                    "createdAt": "2026-09-26T19:46:40.075Z",
                    "updatedAt": "2026-09-26T19:47:13.548Z"
                  }
                ],
                "createdAt": "2025-04-25T15:44:17.016Z",
                "updatedAt": "2025-04-25T15:44:17.016Z"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain")
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

        var response = await Client.PaymentMethodDomain.AddPaymentMethodDomainAsync(
            new AddPaymentMethodDomainRequest
            {
                DomainName = "checkout.example.com",
                EntityId = 109,
                EntityType = "paypoint",
                ApplePay = new AddPaymentMethodDomainRequestApplePay { IsEnabled = true },
                GooglePay = new AddPaymentMethodDomainRequestGooglePay { IsEnabled = true },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AddPaymentMethodDomainApiResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
