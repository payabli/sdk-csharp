using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Paypoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetPaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoint retrieved successfully",
              "traceId": "0HNNN6HH5NDB3:00000002",
              "data": {
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "parentPaypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "paypointType": "merchant",
                "paypointStatus": "pending",
                "doingBusinessAs": "Rose Gardens",
                "entryName": "8cfec329267",
                "description": "Boutique flower shop",
                "website": "https://example.com",
                "timezone": "America/New_York",
                "customerServicePhone": "3055551212",
                "customerServiceEmail": "support@example.com",
                "createdAt": "2026-08-11T10:36:04.115771",
                "updatedAt": "2026-08-11T10:36:04.115788",
                "_links": {
                  "self": "/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c")
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

        var response = await Client.Paypoints.GetPaypointAsync(
            "019ff064-c690-7679-a73e-688418aadc7c"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
