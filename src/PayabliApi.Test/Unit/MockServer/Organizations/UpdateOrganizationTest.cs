using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Organizations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateOrganizationTest : BaseMockServerTest
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
              "message": "Organization updated successfully",
              "traceId": "0HNPE4LB0RHAE:0000003F",
              "data": {
                "paypointReference": "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
                "updatedAt": "2026-10-20T22:20:37.346Z",
                "_links": {
                  "self": "/v2/organizations/a8806f02-23b3-4f6d-bba3-42e1b94326ea"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/organizations/a8806f02-23b3-4f6d-bba3-42e1b94326ea")
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

        var response = await Client.Organizations.UpdateOrganizationAsync(
            "a8806f02-23b3-4f6d-bba3-42e1b94326ea",
            new UpdateOrganizationRequest { Description = "Updated description" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
