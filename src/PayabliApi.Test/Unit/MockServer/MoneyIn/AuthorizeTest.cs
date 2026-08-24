using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AuthorizeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "paymentDetails": {
                "totalAmount": 1.1
              },
              "paymentMethod": {
                "cardexp": "cardexp",
                "cardnumber": "cardnumber",
                "method": "card"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "responseText",
              "isSuccess": true,
              "pageIdentifier": "pageIdentifier",
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
                    .WithPath("/MoneyIn/authorize")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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

        var response = await Client.MoneyIn.AuthorizeAsync(
            new RequestPaymentAuthorize
            {
                Body = new TransRequestBody
                {
                    PaymentDetails = new PaymentDetail { TotalAmount = 1.1 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardexp = "cardexp",
                        Cardnumber = "cardnumber",
                        Method = PayMethodCreditMethod.Card,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
