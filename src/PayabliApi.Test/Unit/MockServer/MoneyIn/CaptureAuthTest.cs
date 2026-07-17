using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "SUCCESS"
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
        JsonAssert.AreEqual(response, mockResponse);
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
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "SUCCESS"
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
        JsonAssert.AreEqual(response, mockResponse);
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
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "123456",
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "SUCCESS"
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
        JsonAssert.AreEqual(response, mockResponse);
    }
}
