using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CascadePaymentMethodDomainTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                  "isEnabled": true,
                  "data": null
                },
                "googlePay": {
                  "isEnabled": true,
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
                "updatedAt": "2025-04-25T15:38:46.804Z"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/pmd_b8237fa45c964d8a9ef27160cd42b8c5/cascade")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.CascadePaymentMethodDomainAsync(
            "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
