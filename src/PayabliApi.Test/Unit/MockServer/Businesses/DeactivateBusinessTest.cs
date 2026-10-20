using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DeactivateBusinessTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "reason": "Duplicate record"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Business deactivated successfully",
              "traceId": "0HNNKQIN7BJQM:0000003D",
              "data": {
                "_links": {
                  "self": "/v2/businesses/019fed33-615d-77b6-afaa-46e7ac9bf36e"
                },
                "businessUuid": "019fed33-615d-77b6-afaa-46e7ac9bf36e",
                "businessStatus": "Deactivated",
                "deactivatedAt": "2026-08-10T19:43:15.380Z",
                "reason": "Duplicate record"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses/019fed33-615d-77b6-afaa-46e7ac9bf36e")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingDelete()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Businesses.DeactivateBusinessAsync(
            "019fed33-615d-77b6-afaa-46e7ac9bf36e",
            new DeactivateBusinessRequest { Reason = "Duplicate record" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
