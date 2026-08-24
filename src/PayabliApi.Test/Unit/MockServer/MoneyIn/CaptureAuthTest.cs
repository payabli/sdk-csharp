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
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 1.1
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": "pageIdentifier",
              "roomId": 1000000,
              "isSuccess": true,
              "responseText": "responseText",
              "responseData": {
                "authCode": "authCode",
                "referenceId": "referenceId",
                "resultCode": 1,
                "resultText": "resultText",
                "avsResponseText": "avsResponseText",
                "cvvResponseText": "cvvResponseText",
                "customerId": 1000000,
                "methodReferenceId": "methodReferenceId"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/capture/transId")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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
            "transId",
            new CaptureRequest { PaymentDetails = new CapturePaymentDetails { TotalAmount = 1.1 } }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
