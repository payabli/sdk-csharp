using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApplicationEnablementTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Application boarding status",
              "traceId": "0HNP4OL9M4GDO:00000001",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "state": "Submitted",
                "services": [
                  {
                    "service": "Card",
                    "rail": "MoneyIn",
                    "state": "Submitted"
                  }
                ],
                "blockedOn": "processor",
                "message": "Boarding is waiting on a processor for at least one service and is retried automatically. The service list says which. It has been attempted 63 times so far.",
                "attempts": 63,
                "firstAttemptAt": "2026-10-12T18:41:18.945Z",
                "lastAttemptAt": "2026-10-12T19:43:10.983Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/enablement")
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

        var response = await Client.Applications.GetApplicationEnablementAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Application boarding status",
              "traceId": "0HNP4OM1AUIS4:00000002",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "services": []
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c/enablement")
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

        var response = await Client.Applications.GetApplicationEnablementAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
