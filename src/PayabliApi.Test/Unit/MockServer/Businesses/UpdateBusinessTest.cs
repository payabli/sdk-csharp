using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateBusinessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "website": "https://example.org"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Business updated successfully",
              "traceId": "0HNNKQIN7BJO1:00000016",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                },
                "businessUuid": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "lastUpdated": "2026-08-10T19:15:47.955Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.UpdateBusinessAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            new UpdateBusinessRequest { Website = "https://example.org" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
