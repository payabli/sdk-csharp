using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Application retrieved successfully",
              "traceId": "0HNNNPRPLVN3H:00000009",
              "data": {
                "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "externalId": "APP-2025-0417",
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "paypointStatus": "pending",
                "applicationStatus": "draft",
                "applicationStatusCode": 1,
                "allowedActions": [
                  "submit",
                  "withdraw",
                  "abandon"
                ],
                "tags": [
                  "priority"
                ],
                "createdAt": "2026-07-01T15:00:01.734346",
                "_links": {
                  "self": "/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests/3f3caa7b-bdfe-4bf1-814b-30d54859247c")
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

        var response = await Client.Applications.GetApplicationAsync(
            "3f3caa7b-bdfe-4bf1-814b-30d54859247c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
