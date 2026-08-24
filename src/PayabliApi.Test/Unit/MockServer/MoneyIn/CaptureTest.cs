using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CaptureTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
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
                    .WithPath("/MoneyIn/capture/transId/1.1")
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

        var response = await Client.MoneyIn.CaptureAsync("transId", 1.1);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
