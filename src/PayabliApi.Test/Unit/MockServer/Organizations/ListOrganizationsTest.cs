using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOrganizationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Organizations retrieved successfully",
              "traceId": "0HNPE4LGV825H:00000033",
              "data": {
                "items": [
                  {
                    "paypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                    "externalId": "pmp-org-001",
                    "businessReference": "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
                    "parentPaypointReference": "3c7f1a9e-5d2b-4e84-a6c0-8b1f4d7e2a95",
                    "paypointType": "organization",
                    "paypointStatus": "pending",
                    "doingBusinessAs": "PropertyManager Pro",
                    "description": "Property management software partner",
                    "website": "https://example.com",
                    "timezone": "America/New_York",
                    "entryName": "8cfec329267",
                    "createdAt": "2026-10-20T22:20:37.029589",
                    "updatedAt": "2026-10-20T22:20:37.029589",
                    "_links": {
                      "self": "/v2/organizations/a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                      "business": "/v2/businesses/6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27"
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
                    .WithPath("/v2/organizations")
                    .WithParam("businessReference", "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27")
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

        var response = await Client.Organizations.ListOrganizationsAsync(
            new ListOrganizationsOrganizationsRequest
            {
                BusinessReference = "6e2b9d14-7a3c-4f58-b1e6-0c9d3a5f8e27",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
