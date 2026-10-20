using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Paypoints;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPaypointsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoints retrieved successfully",
              "traceId": "0HNNN6HH5NDBG:00000018",
              "data": {
                "items": [
                  {
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
                ],
                "total": 1,
                "page": 1,
                "pageSize": 1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints")
                    .WithParam("limit", "1")
                    .WithParam("page", "1")
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

        var response = await Client.Paypoints.ListPaypointsAsync(
            new ListPaypointsPaypointsRequest { Limit = 1, Page = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Paypoints retrieved successfully",
              "traceId": "0HNONVR8FHLEO:0000005A",
              "data": {
                "items": [
                  {
                    "paypointReference": "019ff064-c690-7679-a73e-688418aadc7c",
                    "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                    "parentPaypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                    "paypointType": "merchant",
                    "paypointStatus": "pending",
                    "doingBusinessAs": "Rose Gardens",
                    "entryName": "8cfec329267",
                    "createdAt": "2026-08-11T10:36:04.115771",
                    "updatedAt": "2026-08-11T10:36:04.115788",
                    "_links": {
                      "self": "/v2/paypoints/019ff064-c690-7679-a73e-688418aadc7c",
                      "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                    }
                  }
                ],
                "total": 1,
                "page": 1,
                "pageSize": 25
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/paypoints")
                    .WithParam("businessReference", "019fed1a-3d6e-75d3-a81e-cba3874b0a55")
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

        var response = await Client.Paypoints.ListPaypointsAsync(
            new ListPaypointsPaypointsRequest
            {
                BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
