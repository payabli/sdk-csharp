using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RefundWithInstructionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "responseText": "responseText",
              "isSuccess": true,
              "responseData": {
                "authCode": "authCode",
                "expectedProcessingDateTime": "2024-01-15T09:30:00.000Z",
                "avsResponseText": "avsResponseText",
                "customerId": 1000000,
                "cvvResponseText": "cvvResponseText",
                "methodReferenceId": "methodReferenceId",
                "referenceId": "referenceId",
                "resultCode": 1,
                "resultText": "resultText"
              },
              "pageidentifier": "pageidentifier"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/refund/transId")
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

        var response = await Client.MoneyIn.RefundWithInstructionsAsync(
            "transId",
            new RequestRefund()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
