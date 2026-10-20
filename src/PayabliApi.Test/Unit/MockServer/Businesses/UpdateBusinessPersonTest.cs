using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateBusinessPersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "primaryEmail": "updated.contact@example.com",
              "isPrimaryController": true
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Business person updated successfully",
              "traceId": "0HNOIME81PCS8:00000582",
              "data": {
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "personType": "owner",
                "ownershipPercentage": 100,
                "beneficialOwner": true,
                "isPrimaryController": true,
                "isSigner": true,
                "title": "CEO",
                "primaryEmail": "updated.contact@example.com",
                "secondaryEmail": "contact.alt@example.net",
                "primaryPhoneNumber": "3055551212",
                "secondaryPhoneNumber": "3055559876",
                "createdAt": "2026-08-14T17:24:31.387Z",
                "updatedAt": "2026-08-14T17:26:08.911Z",
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/people/01a0014d-ce1a-7110-9bac-c4c59647a88d",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                  "person": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                    )
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

        var response = await Client.Businesses.UpdateBusinessPersonAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            "01a0014d-ce1a-7110-9bac-c4c59647a88d",
            new UpdateBusinessPersonRequest
            {
                PrimaryEmail = "updated.contact@example.com",
                IsPrimaryController = true,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
