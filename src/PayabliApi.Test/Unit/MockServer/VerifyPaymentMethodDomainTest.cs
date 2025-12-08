using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class VerifyPaymentMethodDomainTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
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
                "updatedAt": "2025-04-25T15:45:21.517Z"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/pmd_b8237fa45c964d8a9ef27160cd42b8c5/verify")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.VerifyPaymentMethodDomainAsync(
            "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "isSuccess": false,
              "pageidentifier": "null",
              "responseData": {
                "id": "pmd_b8237fa45c964d8a9ef27160cd42b8c5",
                "type": "PaymentMethodDomains",
                "entityId": 78,
                "entityType": "organization",
                "domainName": "checkout.example.com",
                "applePay": {
                  "isEnabled": true,
                  "data": {
                    "errorMessage": "Unable to validate the domain. Verification file not found at https://checkout.example.com/.well-known/apple-developer-merchantid-domain-association",
                    "metadata": {
                      "isFileAvailable": false,
                      "isFileContentValid": false,
                      "statusCode": 404,
                      "redirectUrl": null,
                      "redirectDomainName": null
                    }
                  }
                },
                "googlePay": {
                  "isEnabled": true,
                  "data": {
                    "errorMessage": "Unable to validate the domain. Domain not found.",
                    "metadata": {
                      "statusCode": 404,
                      "redirectUrl": null,
                      "redirectDomainName": null
                    }
                  }
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
                "updatedAt": "2025-04-25T15:45:21.517Z"
              },
              "responseText": "Failed"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentMethodDomain/pmd_b8237fa45c964d8a9ef27160cd42b8c5/verify")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentMethodDomain.VerifyPaymentMethodDomainAsync(
            "pmd_b8237fa45c964d8a9ef27160cd42b8c5"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PaymentMethodDomainGeneralResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
