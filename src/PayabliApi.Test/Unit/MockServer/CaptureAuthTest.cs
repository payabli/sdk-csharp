using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class CaptureAuthTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 105,
                "serviceFee": 5
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
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
                    .WithPath("/MoneyIn/capture/10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.CaptureAuthAsync(
            "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
            new CaptureRequest
            {
                PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 89,
                "serviceFee": 4
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
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
                    .WithPath("/MoneyIn/capture/10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.CaptureAuthAsync(
            "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
            new CaptureRequest
            {
                PaymentDetails = new CapturePaymentDetails { TotalAmount = 89, ServiceFee = 4 },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 100
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
                "resultCode": 1,
                "resultText": "SUCCESS",
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
                    .WithPath("/MoneyIn/capture/10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.CaptureAuthAsync(
            "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
            new CaptureRequest { PaymentDetails = new CapturePaymentDetails { TotalAmount = 100 } }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<CaptureResponse>(mockResponse)).UsingDefaults()
        );
    }
}
