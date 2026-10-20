using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchPeopleTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "firstName": "Marcus",
              "lastName": "Delgado"
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "People search completed",
              "traceId": "0HNONVR8FH4GO:00000030",
              "data": {
                "results": [
                  {
                    "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                    "firstName": "Marcus",
                    "lastName": "Delgado",
                    "dateOfBirth": "****-**-14",
                    "primaryEmail": "marcus.delgado@example.com",
                    "primaryPhone": "+13055551212",
                    "matchScore": 0.6,
                    "isTopMatch": true,
                    "isFromVendor": false,
                    "phones": [
                      "+13055551212"
                    ],
                    "emails": [
                      "marcus.delgado@example.com"
                    ],
                    "addressCount": 0,
                    "phoneCount": 1,
                    "emailCount": 1
                  }
                ],
                "total": 1,
                "isEnrichedByVendor": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people/search")
                    .WithParam("entry", "8cfec329267")
                    .WithParam("orgId", "123")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.People.SearchPeopleAsync(
            new SearchPeopleRequest
            {
                Entry = "8cfec329267",
                OrgId = 123,
                Body = new Dictionary<object, object?>()
                {
                    { "firstName", "Marcus" },
                    { "lastName", "Delgado" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
