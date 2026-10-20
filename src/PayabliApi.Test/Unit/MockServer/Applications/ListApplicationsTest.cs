using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Applications;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListApplicationsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "message": "Applications retrieved successfully",
              "traceId": "0HNNNPRPLVN3G:00000004",
              "data": {
                "data": [
                  {
                    "requestsReference": "3f3caa7b-bdfe-4bf1-814b-30d54859247c",
                    "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                    "parent": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                    "parentOrgName": "PropertyManager Pro",
                    "paypointName": "Rose Gardens",
                    "paypointLegalName": "Rose Gardens LLC",
                    "ein": "****8993",
                    "primaryOwnerName": "Marcus Delgado",
                    "primaryOwnerReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                    "externalId": "APP-2025-0417",
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
                ],
                "total": 1,
                "page": 1,
                "pageSize": 20
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/requests")
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

        var response = await Client.Applications.ListApplicationsAsync(
            new ListApplicationsApplicationsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
