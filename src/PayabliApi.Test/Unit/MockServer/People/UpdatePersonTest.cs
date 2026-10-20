using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "primaryPhoneNumber": "3055550199"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Person updated successfully",
              "traceId": "0HNNQ4R2OT26Q:00000027",
              "data": {
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "lastUpdated": "2026-08-14T17:27:06.447Z",
                "_links": {
                  "self": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d")
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

        var response = await Client.People.UpdatePersonAsync(
            "01a0014d-ce1a-7110-9bac-c4c59647a88d",
            new UpdatePersonRequest { PrimaryPhoneNumber = "3055550199" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
