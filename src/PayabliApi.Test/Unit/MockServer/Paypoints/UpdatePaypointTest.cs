using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Paypoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePaypointTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "description": "Updated description"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoint updated successfully",
              "traceId": "0HNNN6HH5ND71:00000268",
              "data": {
                "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                "updatedAt": "2026-08-11T10:36:04.462Z",
                "_links": {
                  "self": "/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c"
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

        var response = await Client.Paypoints.UpdatePaypointAsync(
            "019ff064-c690-7679-a73e-688418aadc7c",
            new UpdatePaypointRequest { Description = "Updated description" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
