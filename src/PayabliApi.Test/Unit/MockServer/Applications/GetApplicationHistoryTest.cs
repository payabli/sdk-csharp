using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApplicationHistoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Application status history",
              "traceId": "0HNNNPRPLVN4C:0000001C",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "history": [
                  {
                    "fromStatus": "none",
                    "toStatus": "draft",
                    "trigger": "Create",
                    "actor": "0",
                    "createdAt": "2026-07-01T15:00:01.734346"
                  },
                  {
                    "fromStatus": "draft",
                    "toStatus": "withdrawn",
                    "trigger": "Withdraw",
                    "actor": "0",
                    "reason": "Duplicate application",
                    "createdAt": "2026-07-01T15:12:44.132073"
                  }
                ]
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/history")
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

        var response = await Client.Applications.GetApplicationHistoryAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
