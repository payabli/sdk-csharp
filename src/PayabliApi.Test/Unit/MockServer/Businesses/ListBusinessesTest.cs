using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListBusinessesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Businesses retrieved successfully",
              "traceId": "0HNNKQIN7BJO2:00000024",
              "data": {
                "data": [
                  {
                    "_links": {
                      "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                    },
                    "businessUuid": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                    "legalName": "Rose Gardens LLC",
                    "businessStatus": "Draft",
                    "parentReference": "8cfec329267",
                    "createdAt": "2026-08-10T19:15:47.694Z",
                    "lastUpdated": "2026-08-10T19:15:47.694Z"
                  }
                ],
                "pagination": {
                  "page": 1,
                  "totalPages": 1,
                  "totalRecords": 1,
                  "pageSize": 1,
                  "hasNext": false,
                  "hasPrevious": false
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses")
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

        var response = await Client.Businesses.ListBusinessesAsync(
            new ListBusinessesBusinessesRequest { Limit = 1, Page = 1 }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
