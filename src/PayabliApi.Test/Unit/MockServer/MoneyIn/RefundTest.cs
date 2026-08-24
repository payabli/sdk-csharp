using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RefundTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/MoneyIn/refund/transId/1.1")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.RefundAsync("transId", 1.1);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
