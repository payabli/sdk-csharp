using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ProvideDocumentsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Documents provided",
              "traceId": "0HNONVR8FH0H0:00000182",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "applicationStatus": "pendingreview",
                "allowedActions": [
                  "approve",
                  "deny",
                  "escalate",
                  "requestDocuments",
                  "requestResponse",
                  "markError"
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/provide-documents")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Applications.ProvideDocumentsAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
